﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PayTracker.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color backColor {
            get {
                return ((global::System.Drawing.Color)(this["backColor"]));
            }
            set {
                this["backColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color foreColor {
            get {
                return ((global::System.Drawing.Color)(this["foreColor"]));
            }
            set {
                this["foreColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string lastSelect {
            get {
                return ((string)(this["lastSelect"]));
            }
            set {
                this["lastSelect"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color buttonForeColor {
            get {
                return ((global::System.Drawing.Color)(this["buttonForeColor"]));
            }
            set {
                this["buttonForeColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color selectionBack {
            get {
                return ((global::System.Drawing.Color)(this["selectionBack"]));
            }
            set {
                this["selectionBack"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color selectionFore {
            get {
                return ((global::System.Drawing.Color)(this["selectionFore"]));
            }
            set {
                this["selectionFore"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color headerBack {
            get {
                return ((global::System.Drawing.Color)(this["headerBack"]));
            }
            set {
                this["headerBack"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color headerFore {
            get {
                return ((global::System.Drawing.Color)(this["headerFore"]));
            }
            set {
                this["headerFore"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color cellFore {
            get {
                return ((global::System.Drawing.Color)(this["cellFore"]));
            }
            set {
                this["cellFore"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color cellBack {
            get {
                return ((global::System.Drawing.Color)(this["cellBack"]));
            }
            set {
                this["cellBack"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color selectionHeaderBack {
            get {
                return ((global::System.Drawing.Color)(this["selectionHeaderBack"]));
            }
            set {
                this["selectionHeaderBack"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color selectionHeaderFore {
            get {
                return ((global::System.Drawing.Color)(this["selectionHeaderFore"]));
            }
            set {
                this["selectionHeaderFore"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color selectionCellFore {
            get {
                return ((global::System.Drawing.Color)(this["selectionCellFore"]));
            }
            set {
                this["selectionCellFore"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color selectionCellBack {
            get {
                return ((global::System.Drawing.Color)(this["selectionCellBack"]));
            }
            set {
                this["selectionCellBack"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Data.mdf;Integrated " +
            "Security=True")]
        public string DataConnectionString {
            get {
                return ((string)(this["DataConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool FirstStart {
            get {
                return ((bool)(this["FirstStart"]));
            }
            set {
                this["FirstStart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DatabaseType {
            get {
                return ((string)(this["DatabaseType"]));
            }
            set {
                this["DatabaseType"] = value;
            }
        }
    }
}
