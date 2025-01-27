//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Schemas.AspNetSiteMaps {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Diagnostics;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Linq;
    using Xml.Schema.Linq;
    
    
    /// <summary>
    /// <para>
    /// Regular expression: (siteMapNode)*
    /// </para>
    /// </summary>
    public partial class siteMapNodeType : XTypedElement, IXMetaData {
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly System.Xml.Linq.XName siteMapNodeXName = System.Xml.Linq.XName.Get("siteMapNode", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XTypedList<siteMapNodeType> siteMapNodeField;
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly System.Xml.Linq.XName urlXName = System.Xml.Linq.XName.Get("url", "");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly System.Xml.Linq.XName titleXName = System.Xml.Linq.XName.Get("title", "");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly System.Xml.Linq.XName descriptionXName = System.Xml.Linq.XName.Get("description", "");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly System.Xml.Linq.XName rolesXName = System.Xml.Linq.XName.Get("roles", "");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly System.Xml.Linq.XName resourceKeyXName = System.Xml.Linq.XName.Get("resourceKey", "");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly System.Xml.Linq.XName siteMapFileXName = System.Xml.Linq.XName.Get("siteMapFile", "");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly System.Xml.Linq.XName securityTrimmingEnabledXName = System.Xml.Linq.XName.Get("securityTrimmingEnabled", "");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string securityTrimmingEnabledDefaultValue = "false";
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly System.Xml.Linq.XName providerXName = System.Xml.Linq.XName.Get("provider", "");
        
        private static readonly System.Xml.Linq.XName xName = System.Xml.Linq.XName.Get("siteMapNodeType", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static Dictionary<System.Xml.Linq.XName, System.Type> localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();
        
		public static explicit operator siteMapNodeType(XElement xe) { return XTypedServices.ToXTypedElement<siteMapNodeType>(xe,LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }
        
        static siteMapNodeType() {
            BuildElementDictionary();
        }
        
        /// <summary>
        /// <para>
        /// Regular expression: (siteMapNode)*
        /// </para>
        /// </summary>
        public siteMapNodeType() {
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: required, choice
        /// </para>
        /// <para>
        /// Regular expression: (siteMapNode)*
        /// </para>
        /// </summary>
        public virtual IList<siteMapNodeType> siteMapNode {
            get {
                if ((this.siteMapNodeField == null)) {
                    this.siteMapNodeField = new XTypedList<siteMapNodeType>(this, LinqToXsdTypeManager.Instance, siteMapNodeXName);
                }
                return this.siteMapNodeField;
            }
            set {
                if ((value == null)) {
                    this.siteMapNodeField = null;
                }
                else {
                    if ((this.siteMapNodeField == null)) {
                        this.siteMapNodeField = XTypedList<siteMapNodeType>.Initialize(this, LinqToXsdTypeManager.Instance, value, siteMapNodeXName);
                    }
                    else {
                        XTypedServices.SetList<siteMapNodeType>(this.siteMapNodeField, value);
                    }
                }
            }
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public virtual System.Uri url {
            get {
                XAttribute x = this.Attribute(urlXName);
                return XTypedServices.ParseValue<System.Uri>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyUri).Datatype);
            }
            set {
                this.SetAttribute(urlXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyUri).Datatype);
            }
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public virtual string title {
            get {
                XAttribute x = this.Attribute(titleXName);
                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
            set {
                this.SetAttribute(titleXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public virtual string description {
            get {
                XAttribute x = this.Attribute(descriptionXName);
                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
            set {
                this.SetAttribute(descriptionXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public virtual string roles {
            get {
                XAttribute x = this.Attribute(rolesXName);
                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
            set {
                this.SetAttribute(rolesXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public virtual string resourceKey {
            get {
                XAttribute x = this.Attribute(resourceKeyXName);
                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
            set {
                this.SetAttribute(resourceKeyXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public virtual string siteMapFile {
            get {
                XAttribute x = this.Attribute(siteMapFileXName);
                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
            set {
                this.SetAttribute(siteMapFileXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public virtual string securityTrimmingEnabled {
            get {
                XAttribute x = this.Attribute(securityTrimmingEnabledXName);
                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.NmToken).Datatype, securityTrimmingEnabledDefaultValue);
            }
            set {
                this.SetAttribute(securityTrimmingEnabledXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.NmToken).Datatype);
            }
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public virtual string provider {
            get {
                XAttribute x = this.Attribute(providerXName);
                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
            set {
                this.SetAttribute(providerXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Dictionary<System.Xml.Linq.XName, System.Type> IXMetaData.LocalElementsDictionary {
            get {
                return localElementDictionary;
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        System.Xml.Linq.XName IXMetaData.SchemaName {
            get {
                return xName;
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        SchemaOrigin IXMetaData.TypeOrigin {
            get {
                return SchemaOrigin.Fragment;
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILinqToXsdTypeManager IXMetaData.TypeManager {
            get {
                return LinqToXsdTypeManager.Instance;
            }
        }
        
        public override XTypedElement Clone() {
            return XTypedServices.CloneXTypedElement<siteMapNodeType>(this);
        }
        
        private static void BuildElementDictionary() {
            localElementDictionary.Add(siteMapNodeXName, typeof(siteMapNodeType));
        }
        
        ContentModelEntity IXMetaData.GetContentModel() {
            return ContentModelEntity.Default;
        }
    }
    
    /// <summary>
    /// <para>
    /// Regular expression: (siteMapNode)?
    /// </para>
    /// </summary>
    public partial class siteMapType : XTypedElement, IXMetaData {
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly System.Xml.Linq.XName siteMapNodeXName = System.Xml.Linq.XName.Get("siteMapNode", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly System.Xml.Linq.XName enableLocalizationXName = System.Xml.Linq.XName.Get("enableLocalization", "");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static string enableLocalizationDefaultValue = "false";
        
        private static readonly System.Xml.Linq.XName xName = System.Xml.Linq.XName.Get("siteMapType", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static Dictionary<System.Xml.Linq.XName, System.Type> localElementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static ContentModelEntity contentModel;
        
		public static explicit operator siteMapType(XElement xe) { return XTypedServices.ToXTypedElement<siteMapType>(xe,LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }
        
        static siteMapType() {
            BuildElementDictionary();
            contentModel = new ChoiceContentModelEntity(new NamedContentModelEntity(siteMapNodeXName));
        }
        
        /// <summary>
        /// <para>
        /// Regular expression: (siteMapNode)?
        /// </para>
        /// </summary>
        public siteMapType() {
        }
        
        public siteMapType(siteMapNodeType siteMapNode) {
            this.siteMapNode = siteMapNode;
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: required, choice
        /// </para>
        /// <para>
        /// Regular expression: (siteMapNode)?
        /// </para>
        /// </summary>
        public virtual siteMapNodeType siteMapNode {
            get {
                XElement x = this.GetElement(siteMapNodeXName);
                return ((siteMapNodeType)(x));
            }
            set {
                this.SetElement(siteMapNodeXName, value);
            }
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public virtual string enableLocalization {
            get {
                XAttribute x = this.Attribute(enableLocalizationXName);
                return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.NmToken).Datatype, enableLocalizationDefaultValue);
            }
            set {
                this.SetAttribute(enableLocalizationXName, value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.NmToken).Datatype);
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Dictionary<System.Xml.Linq.XName, System.Type> IXMetaData.LocalElementsDictionary {
            get {
                return localElementDictionary;
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        System.Xml.Linq.XName IXMetaData.SchemaName {
            get {
                return xName;
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        SchemaOrigin IXMetaData.TypeOrigin {
            get {
                return SchemaOrigin.Fragment;
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILinqToXsdTypeManager IXMetaData.TypeManager {
            get {
                return LinqToXsdTypeManager.Instance;
            }
        }
        
        public override XTypedElement Clone() {
            return XTypedServices.CloneXTypedElement<siteMapType>(this);
        }
        
        private static void BuildElementDictionary() {
            localElementDictionary.Add(siteMapNodeXName, typeof(siteMapNodeType));
        }
        
        ContentModelEntity IXMetaData.GetContentModel() {
            return contentModel;
        }
    }
    
    public sealed class small_boolean_Type {
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static Xml.Schema.Linq.SimpleTypeValidator TypeDefinition = new Xml.Schema.Linq.AtomicSimpleTypeValidator(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.NmToken), new Xml.Schema.Linq.RestrictionFacets(((Xml.Schema.Linq.RestrictionFlags)(16)), new object[] {
                        "false",
                        "true"}, 0, 0, null, null, 0, null, null, 0, null, 0, XmlSchemaWhiteSpace.Collapse));
        
        private small_boolean_Type() {
        }
    }
    
    public partial class siteMap : XTypedElement, IXMetaData {
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private siteMapType ContentField;
        
        private static readonly System.Xml.Linq.XName xName = System.Xml.Linq.XName.Get("siteMap", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
        
		public static explicit operator siteMap(XElement xe) { return XTypedServices.ToXTypedElement<siteMap, siteMapType>(xe,LinqToXsdTypeManager.Instance as ILinqToXsdTypeManager); }
        
        public siteMap() {
            SetInnerType(new siteMapType());
        }
        
        public siteMap(siteMapType content) {
            SetInnerType(content);
        }
        
        public override XElement Untyped {
            get {
                return base.Untyped;
            }
            set {
                base.Untyped = value;
                this.ContentField.Untyped = value;
            }
        }
        
        public virtual siteMapType Content {
            get {
                return ContentField;
            }
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: required, choice
        /// </para>
        /// <para>
        /// Regular expression: (siteMapNode)?
        /// </para>
        /// </summary>
        public virtual siteMapNodeType siteMapNode {
            get {
                return this.ContentField.siteMapNode;
            }
            set {
                this.ContentField.siteMapNode = value;
            }
        }
        
        /// <summary>
        /// <para>
        /// Occurrence: optional
        /// </para>
        /// </summary>
        public virtual string enableLocalization {
            get {
                return this.ContentField.enableLocalization;
            }
            set {
                this.ContentField.enableLocalization = value;
            }
        }
        
        Dictionary<System.Xml.Linq.XName, System.Type> IXMetaData.LocalElementsDictionary {
            get {
                IXMetaData schemaMetaData = ((IXMetaData)(this.Content));
                return schemaMetaData.LocalElementsDictionary;
            }
        }
        
        XTypedElement IXMetaData.Content {
            get {
                return this.Content;
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        System.Xml.Linq.XName IXMetaData.SchemaName {
            get {
                return xName;
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        SchemaOrigin IXMetaData.TypeOrigin {
            get {
                return SchemaOrigin.Element;
            }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILinqToXsdTypeManager IXMetaData.TypeManager {
            get {
                return LinqToXsdTypeManager.Instance;
            }
        }
        
        public void Save(string xmlFile) {
            XTypedServices.Save(xmlFile, Untyped);
        }
        
        public void Save(System.IO.TextWriter tw) {
            XTypedServices.Save(tw, Untyped);
        }
        
        public void Save(System.Xml.XmlWriter xmlWriter) {
            XTypedServices.Save(xmlWriter, Untyped);
        }
        
        public static siteMap Load(string xmlFile) {
            return XTypedServices.Load<siteMap, siteMapType>(xmlFile, LinqToXsdTypeManager.Instance);
        }
        
        public static siteMap Load(System.IO.TextReader xmlFile) {
            return XTypedServices.Load<siteMap, siteMapType>(xmlFile, LinqToXsdTypeManager.Instance);
        }
        
        public static siteMap Parse(string xml) {
            return XTypedServices.Parse<siteMap, siteMapType>(xml, LinqToXsdTypeManager.Instance);
        }
        
        public override XTypedElement Clone() {
            return new siteMap(((siteMapType)(this.Content.Clone())));
        }
        
        private void SetInnerType(siteMapType ContentField) {
            this.ContentField = ((siteMapType)(XTypedServices.GetCloneIfRooted(ContentField)));
            XTypedServices.SetName(this, this.ContentField);
        }
        
        ContentModelEntity IXMetaData.GetContentModel() {
            return ContentModelEntity.Default;
        }
    }
    
    public class LinqToXsdTypeManager : ILinqToXsdTypeManager {
        
        private static Dictionary<System.Xml.Linq.XName, System.Type> typeDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();
        
        private static Dictionary<System.Xml.Linq.XName, System.Type> elementDictionary = new Dictionary<System.Xml.Linq.XName, System.Type>();
        
        private static Dictionary<System.Type, System.Type> wrapperDictionary = new Dictionary<System.Type, System.Type>();
        
        private static XmlSchemaSet schemaSet;
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static LinqToXsdTypeManager typeManagerSingleton = new LinqToXsdTypeManager();
        
        static LinqToXsdTypeManager() {
            BuildTypeDictionary();
            BuildElementDictionary();
            BuildWrapperDictionary();
        }
        
        private LinqToXsdTypeManager() {
        }
        
        XmlSchemaSet ILinqToXsdTypeManager.Schemas {
            get {
                if ((schemaSet == null)) {
                    XmlSchemaSet tempSet = new XmlSchemaSet();
                    System.Threading.Interlocked.CompareExchange(ref schemaSet, tempSet, null);
                }
                return schemaSet;
            }
            set {
                schemaSet = value;
            }
        }
        
        Dictionary<System.Xml.Linq.XName, System.Type> ILinqToXsdTypeManager.GlobalTypeDictionary {
            get {
                return typeDictionary;
            }
        }
        
        Dictionary<System.Xml.Linq.XName, System.Type> ILinqToXsdTypeManager.GlobalElementDictionary {
            get {
                return elementDictionary;
            }
        }
        
        Dictionary<System.Type, System.Type> ILinqToXsdTypeManager.RootContentTypeMapping {
            get {
                return wrapperDictionary;
            }
        }
        
        public static LinqToXsdTypeManager Instance {
            get {
                return typeManagerSingleton;
            }
        }
        
        private static void BuildTypeDictionary() {
            typeDictionary.Add(System.Xml.Linq.XName.Get("siteMapNodeType", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0"), typeof(global::Microsoft.Schemas.AspNetSiteMaps.siteMapNodeType));
            typeDictionary.Add(System.Xml.Linq.XName.Get("siteMapType", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0"), typeof(global::Microsoft.Schemas.AspNetSiteMaps.siteMapType));
        }
        
        private static void BuildElementDictionary() {
            elementDictionary.Add(System.Xml.Linq.XName.Get("siteMap", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0"), typeof(global::Microsoft.Schemas.AspNetSiteMaps.siteMap));
        }
        
        private static void BuildWrapperDictionary() {
            wrapperDictionary.Add(typeof(Microsoft.Schemas.AspNetSiteMaps.siteMap), typeof(global::Microsoft.Schemas.AspNetSiteMaps.siteMapType));
        }
        
        protected internal static void AddSchemas(XmlSchemaSet schemas) {
            schemas.Add(schemaSet);
        }
        
        public static System.Type GetRootType() {
            return elementDictionary[System.Xml.Linq.XName.Get("siteMap", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0")];
        }
    }
    
    public partial class XRootNamespace {
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XDocument doc;
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XTypedElement rootObject;
        

		public siteMap siteMap {  get {return rootObject as siteMap; } }
        
        private XRootNamespace() {
        }
        
        public XRootNamespace(siteMap root) {
            this.doc = new XDocument(root.Untyped);
            this.rootObject = root;
        }
        
        public virtual XDocument XDocument {
            get {
                return doc;
            }
        }
        
        public virtual XTypedElement Root {
            get {
                return rootObject;
            }
        }
        
        public static XRootNamespace Load(string xmlFile) {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Load(xmlFile);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRootNamespace Load(string xmlFile, LoadOptions options) {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Load(xmlFile, options);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRootNamespace Load(TextReader textReader) {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Load(textReader);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRootNamespace Load(TextReader textReader, LoadOptions options) {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Load(textReader, options);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRootNamespace Load(XmlReader xmlReader) {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Load(xmlReader);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRootNamespace Parse(string text) {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Parse(text);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRootNamespace Parse(string text, LoadOptions options) {
            XRootNamespace root = new XRootNamespace();
            root.doc = XDocument.Parse(text, options);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public virtual void Save(string fileName) {
            doc.Save(fileName);
        }
        
        public virtual void Save(TextWriter textWriter) {
            doc.Save(textWriter);
        }
        
        public virtual void Save(XmlWriter writer) {
            doc.Save(writer);
        }
        
        public virtual void Save(TextWriter textWriter, SaveOptions options) {
            doc.Save(textWriter, options);
        }
        
        public virtual void Save(string fileName, SaveOptions options) {
            doc.Save(fileName, options);
        }
    }
    
    public partial class XRoot {
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XDocument doc;
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XTypedElement rootObject;
        

		public global::Microsoft.Schemas.AspNetSiteMaps.siteMap siteMap {  get {return rootObject as global::Microsoft.Schemas.AspNetSiteMaps.siteMap; } }
        
        private XRoot() {
        }
        
        public XRoot(global::Microsoft.Schemas.AspNetSiteMaps.siteMap root) {
            this.doc = new XDocument(root.Untyped);
            this.rootObject = root;
        }
        
        public virtual XDocument XDocument {
            get {
                return doc;
            }
        }
        
        public virtual XTypedElement Root {
            get {
                return rootObject;
            }
        }
        
        public static XRoot Load(string xmlFile) {
            XRoot root = new XRoot();
            root.doc = XDocument.Load(xmlFile);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRoot Load(string xmlFile, LoadOptions options) {
            XRoot root = new XRoot();
            root.doc = XDocument.Load(xmlFile, options);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRoot Load(TextReader textReader) {
            XRoot root = new XRoot();
            root.doc = XDocument.Load(textReader);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRoot Load(TextReader textReader, LoadOptions options) {
            XRoot root = new XRoot();
            root.doc = XDocument.Load(textReader, options);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRoot Load(XmlReader xmlReader) {
            XRoot root = new XRoot();
            root.doc = XDocument.Load(xmlReader);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRoot Parse(string text) {
            XRoot root = new XRoot();
            root.doc = XDocument.Parse(text);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public static XRoot Parse(string text, LoadOptions options) {
            XRoot root = new XRoot();
            root.doc = XDocument.Parse(text, options);
            XTypedElement typedRoot = XTypedServices.ToXTypedElement(root.doc.Root, LinqToXsdTypeManager.Instance);
            if ((typedRoot == null)) {
                throw new LinqToXsdException("Invalid root element in xml document.");
            }
            root.rootObject = typedRoot;
            return root;
        }
        
        public virtual void Save(string fileName) {
            doc.Save(fileName);
        }
        
        public virtual void Save(TextWriter textWriter) {
            doc.Save(textWriter);
        }
        
        public virtual void Save(XmlWriter writer) {
            doc.Save(writer);
        }
        
        public virtual void Save(TextWriter textWriter, SaveOptions options) {
            doc.Save(textWriter, options);
        }
        
        public virtual void Save(string fileName, SaveOptions options) {
            doc.Save(fileName, options);
        }
    }
}
