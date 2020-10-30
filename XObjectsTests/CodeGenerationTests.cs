using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Resolvers;
using LinqToXsd;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using Xml.Schema.Linq.Extensions;
using Xml.Schema.Linq.CodeGen;

namespace Xml.Schema.Linq.Tests
{
    using SF = SyntaxFactory;

    public class CodeGenerationTests
    {
        private const string AtomXsdFilePath = @"Schemas\Atom\atom.xsd";

        [Test]
        public void NamespaceCodeGenerationConventionTest()
        {
            const string simpleDocXsdFilepath = @"Schemas\Toy schemas\Simple doc.xsd";
            var simpleDocXsd = XmlReader.Create(simpleDocXsdFilepath).ToXmlSchema();

            var sourceText = Utilities.GenerateSourceText(simpleDocXsdFilepath);

            var tree = CSharpSyntaxTree.ParseText(sourceText);
            var namespaceNode = tree.GetNamespaceRoot();

            Assert.IsNotNull(namespaceNode);

            var xmlQualifiedNames = simpleDocXsd.Namespaces.ToArray();
            var nsName = Regex.Replace(xmlQualifiedNames.Last().Namespace, @"\W", "_");
            var cSharpNsName = Regex.Replace(namespaceNode.Name.ToString(), @"\W", "_");

            Assert.IsTrue(cSharpNsName == nsName);
        }

        /// <summary>
        /// Tests the the BuildWrapperDictionary() method of the LinqToXsdTypeManager class that's
        /// generated does not contain <c>typeof(void)</c> expressions, which are meaningless and break
        /// typed XElement conversion.
        /// </summary>
        [Test]
        public void AtomNoVoidTypeOfExpressionsInLinqToXsdTypeManagerBuildWrapperDictionaryMethodTest()
        {
            const string atomDir = @"Schemas\Atom";
            var atomXsdFolder = Path.Combine(Environment.CurrentDirectory, atomDir);
            var atomRssXsdFile = $"{atomXsdFolder}\\atom.xsd";
            var atomRssXsdFileInfo = new FileInfo(atomRssXsdFile);
            var tree = Utilities.GenerateSyntaxTree(atomRssXsdFileInfo);

            var linqToXsdTypeManagerClassDeclarationSyntax = tree.GetNamespaceRoot().DescendantNodes().OfType<ClassDeclarationSyntax>()
                                                                 .FirstOrDefault(cds => cds.Identifier.ValueText == nameof(LinqToXsdTypeManager));

            Assert.IsNotNull(linqToXsdTypeManagerClassDeclarationSyntax);

            var buildWrapperDictionaryMethod = linqToXsdTypeManagerClassDeclarationSyntax
                                               .DescendantNodes().OfType<MethodDeclarationSyntax>()
                                               .FirstOrDefault(mds =>
                                                   mds.Identifier.ValueText == "BuildWrapperDictionary");

            Assert.IsNotNull(buildWrapperDictionaryMethod);

            var statements = buildWrapperDictionaryMethod.DescendantNodes().OfType<InvocationExpressionSyntax>().ToArray();

            Assert.IsTrue(statements.Length == 2);

            var typeOfExpressions = statements.SelectMany(ies => ies.ArgumentList.DescendantNodes()).OfType<TypeOfExpressionSyntax>().ToArray();

            Assert.IsNotEmpty(typeOfExpressions);
            Assert.IsTrue(typeOfExpressions.Length == 4);

            var typeOfVoid = SF.ParseExpression("typeof(void)");
            var nonVoidTypeOfExpressions = typeOfExpressions.Where(toe => !toe.IsEquivalentTo(typeOfVoid)).ToArray();
            var voidTypeOfExpressions = typeOfExpressions.Except(nonVoidTypeOfExpressions).ToArray();

            Assert.IsNotEmpty(nonVoidTypeOfExpressions);
            Assert.IsTrue(nonVoidTypeOfExpressions.Length == 4);

            // if this is not empty, then you have a problem...
            Assert.IsEmpty(voidTypeOfExpressions);
        }

        /// <summary>
        /// There shouldn't be <c>typeof(void)</c> expressions in any generated code.
        /// <para>See commit bc75ea0 which introduced this incorrect behaviour.</para>
        /// </summary>
        [Test]
        public void NoVoidTypeOfExpressionsInGeneratedCodeEver()
        {
            var dir = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Schemas"));
            var allXsds = dir.GetFiles("*.xsd", SearchOption.AllDirectories)
                // Microsoft.Build schemas will have typeof(void) expressions due to the existence of bugs that predate this .net core port
                .Where(f => !f.FullName.Contains("Microsoft.Build.")) 
                .Select(f => f.FullName).ToArray();

            var allProcessableXsds = FileSystemUtilities.ResolvePossibleFileAndFolderPathsToProcessableSchemas(allXsds)
                .Select(fp => new FileInfo(fp));

            foreach (var xsd in allProcessableXsds) {
                var generatedCodeTree = Utilities.GenerateSyntaxTree(xsd);

                var root = generatedCodeTree.GetRoot();

                var allDescendents = root.DescendantNodes().SelectMany(d => d.DescendantNodes());
                var allStatements = allDescendents.OfType<StatementSyntax>();
                var allExpressions = allStatements.SelectMany(s => s.DescendantNodes()).OfType<ExpressionSyntax>();
                var typeOfExpressions = allExpressions.OfType<TypeOfExpressionSyntax>().Distinct().ToArray();

                Assert.IsNotEmpty(typeOfExpressions);

                var typeOfVoid = SF.ParseExpression("typeof(void)");
                var nonVoidTypeOfExpressions = typeOfExpressions.Where(toe => !toe.IsEquivalentTo(typeOfVoid)).ToArray();
                var voidTypeOfExpressions = typeOfExpressions.Where(toe => toe.IsEquivalentTo(typeOfVoid)).ToArray();

                Assert.IsNotEmpty(nonVoidTypeOfExpressions);
                Assert.IsEmpty(voidTypeOfExpressions);
            }
        }

        /// <summary>
        /// Tests that in all the properties generated, there are no <c>void.TypeDefinition</c> expressions.
        /// </summary>
        [Test]
        public void NoVoidTypeDefReferencesInAnyStatementsInClrPropertiesTest()
        {
            const string xsdSchema = @"Schemas\XSD\W3C XMLSchema v1.xsd";
            var xsdCode = Utilities.GenerateSyntaxTree(new FileInfo(xsdSchema));

            var allClasses = xsdCode.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>();
            var allProperties = allClasses.SelectMany(cds => cds.DescendantNodes().OfType<PropertyDeclarationSyntax>())
                .Distinct();

            var readWriteable = (from prop in allProperties
                where prop.AccessorList.Accessors.Any(a => a.IsKind(SyntaxKind.GetAccessorDeclaration) ||
                                                           a.IsKind(SyntaxKind.SetAccessorDeclaration))
                      && prop.AccessorList.Accessors.Count >= 2
                select prop).Distinct();

            var virtualProps = readWriteable.Where(prop => prop.Modifiers.Any(SyntaxKind.VirtualKeyword)).ToList();
            var accessors = virtualProps.SelectMany(prop => prop.AccessorList.Accessors).ToList();
            var getters = accessors.Where(getter => getter.IsKind(SyntaxKind.GetAccessorDeclaration));
            var setters = accessors.Where(setter => setter.IsKind(SyntaxKind.SetAccessorDeclaration));

            var getterStatements = getters.SelectMany(getter => getter.DescendantNodes().OfType<StatementSyntax>());
            var setterStatements = setters.SelectMany(getter => getter.DescendantNodes().OfType<StatementSyntax>());

            var getterReturnStatements = getterStatements.OfType<ReturnStatementSyntax>();
            var getterTypeDefinitionReferences = getterReturnStatements.SelectMany(r => r.DescendantNodes()
                .OfType<PredefinedTypeSyntax>());
            var getterVoidTypeDefinitionReferences =
                getterTypeDefinitionReferences.Where(tdefr => tdefr.Keyword.Text == "void");
            
            var setterExpressionSyntaxStatements = setterStatements.OfType<ExpressionStatementSyntax>();
            var setterTypeDefinitionReferences = setterExpressionSyntaxStatements.SelectMany(s => s.DescendantNodes())
                .OfType<PredefinedTypeSyntax>();
            var setterVoidTypeDefinitionReferences =
                setterTypeDefinitionReferences.Where(tdefr => tdefr.Keyword.Text == "void");
            
            Assert.IsEmpty(setterVoidTypeDefinitionReferences);
            Assert.IsEmpty(getterVoidTypeDefinitionReferences);
        }

        /// <summary>
        /// Tests enums declared at the namespace level.
        /// </summary>
        [Test]
        public void EnumAtNamespaceLevelGenerationTest()
        {
            const string wssXsdFilePath = @"Schemas\SharePoint2010\wss.xsd";
            var wssXsdFileInfo = new FileInfo(wssXsdFilePath);
            var tree = Utilities.GenerateSyntaxTree(wssXsdFileInfo);
            var root = tree.GetNamespaceRoot();

            var namespaceScopedEnums = root.DescendantNodes().OfType<EnumDeclarationSyntax>().ToList();

            Assert.IsNotEmpty(namespaceScopedEnums);
            Assert.IsTrue(namespaceScopedEnums.Count == 46);
        }

        /// <summary>
        /// Tests that all invocations of <see cref="System.Xml.Linq.XName.Get"/> are fully qualified.
        /// </summary>
        [Test]
        public void TestXNameGetInvocationsAreFullyQualified()
        {
            var atomXsdFileInfo = new FileInfo(AtomXsdFilePath);

            var tree = Utilities.GenerateSyntaxTree(atomXsdFileInfo);
            var root = tree.GetNamespaceRoot();

            var allInvocationExpressions = root.DescendantNodes().OfType<InvocationExpressionSyntax>().ToList();

            var xNameInvocationsUpToClassName = (from ie in allInvocationExpressions
                                                 where ie.ToFullString().Contains("System.Xml.Linq.XName")
                                                 select ie).ToList();

            var xNameInvocationsUpToMethodName = (from ie in allInvocationExpressions
                                                  where ie.ToFullString().Contains("System.Xml.Linq.XName.Get(")
                                                  select ie).ToList();

            var xNameInvocationsAbbreviated = (from ie in allInvocationExpressions
                                                  where ie.ToFullString().Contains("XName.Get(")
                                                  select ie).ToList();

            Assert.IsNotEmpty(xNameInvocationsUpToMethodName);
            Assert.IsNotEmpty(xNameInvocationsUpToClassName);
            Assert.IsNotEmpty(xNameInvocationsAbbreviated);

            Assert.IsTrue(xNameInvocationsUpToMethodName.Count == 971);
            Assert.IsTrue(xNameInvocationsUpToClassName.Count == 971);
            Assert.IsTrue(xNameInvocationsAbbreviated.Count == 971);
        }

        /// <summary>
        /// Tests that all fields and properties that have attributes are decorated with the same attribute, <see cref="DebuggerBrowsableAttribute"/>.
        /// </summary>
        [Test]
        public void DebuggerBrowsableAttributesGeneratedTest()
        {
            var atomXsdFileInfo = new FileInfo(AtomXsdFilePath);

            var tree = Utilities.GenerateSyntaxTree(atomXsdFileInfo);
            var root = tree.GetNamespaceRoot();

            var allProperties = root.DescendantNodes().OfType<PropertyDeclarationSyntax>().ToList();
            var allFields = root.DescendantNodes().OfType<FieldDeclarationSyntax>().ToList();

            var allFieldsWithAttrs = (from field in allFields
                                      where field.AttributeLists.Select(al => al.Attributes).Any()
                                      select field).ToList();
            
            var allPropertiesWithAttrs = (from p in allProperties
                                          where p.AttributeLists.Select(al => al.Attributes).Any()
                                          select p).ToList();

            var allPropsAttributes = allPropertiesWithAttrs
                .SelectMany(p => p.AttributeLists.SelectMany(al => al.Attributes)).ToList();

            var allFieldAttributes = allFieldsWithAttrs
                .SelectMany(f => f.AttributeLists.SelectMany(al => al.Attributes)).ToList();

            var allPropAttributeNames = allPropsAttributes.Select(a => ((IdentifierNameSyntax) a.Name).Identifier.Text).ToList();
            var allFieldAttributeNames = allFieldAttributes.Select(a => ((IdentifierNameSyntax) a.Name).Identifier.Text).ToList();
            
            Assert.IsNotEmpty(allPropAttributeNames);
            Assert.IsNotEmpty(allFieldAttributeNames);

            Assert.IsTrue(allPropAttributeNames.Count == 52);
            Assert.IsTrue(allFieldAttributeNames.Count == 58);

            var debuggerBrowsableName = nameof(DebuggerBrowsableAttribute).Replace(nameof(Attribute), string.Empty);
            var allNamesAreTheSame = allPropAttributeNames.Concat(allFieldAttributeNames)
                .All(s => s == debuggerBrowsableName);

            Assert.IsTrue(allNamesAreTheSame);
        }
    }
}