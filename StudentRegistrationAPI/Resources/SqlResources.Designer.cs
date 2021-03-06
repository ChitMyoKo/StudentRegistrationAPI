//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentRegistrationAPI.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class SqlResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("StudentRegistrationAPI.Resources.SqlResources", typeof(SqlResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO TBL_USER
        ///           (USERID
        ///           ,USERNAME
        ///           ,FULLNAME
        ///           ,EMAIL
        ///           ,PASSWORD
        ///           ,ISLOGIN
        ///           ,ISDELETE
        ///           ,CREATEDDATE)
        ///     VALUES
        ///           (@USERID
        ///           ,@USERNAME
        ///           ,@FULLNAME
        ///           ,@EMAIL
        ///           ,@PASSWORD
        ///           ,@ISLOGIN
        ///           ,@ISDELETE
        ///           ,@CREATEDDATE).
        /// </summary>
        public static string CreateUserAccount {
            get {
                return ResourceManager.GetString("CreateUserAccount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE TBL_STUDENT SET ISDELETE = 1, UPDATEDUSERID = @UPDATEDUSERID, UPDATEDATE = @UPDATEDDATE WHERE ID = @ID;.
        /// </summary>
        public static string DeleteStudent {
            get {
                return ResourceManager.GetString("DeleteStudent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO TBL_LOGIN (USERID, SESSIONID, DYNAMICKEY, SESSIONEXPIRDATE, LOGINDATE) VALUES (@USERID, @SESSIONID, @DYNAMICKEY, @SESSIONEXPIREDATE, @LOGINDATE);.
        /// </summary>
        public static string InsertLogin {
            get {
                return ResourceManager.GetString("InsertLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO TBL_STUDENT
        ///(STUDENTNO,NAME,FATHERNAME,NRC,ADDRESS,PHONE,EMAIL,GENDER,DOB,UNIVERSITYID,MAJORID,ACADEMICYEARID,ISDELETE,CREATEDDATE,CREATEDUSERID) 
        ///VALUES (@STUDENTNO,@NAME,@FATHERNAME,@NRC,@ADDRESS,@PHONE,@EMAIL,@GENDER,@DOB,@UNIVERSITYID,@MAJORID,@ACADEMICYEARID,@ISDELETE,@CREATEDDATE,@CREATEDUSERID);.
        /// </summary>
        public static string InsertStudent {
            get {
                return ResourceManager.GetString("InsertStudent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM [TBL_ACADEMICYEAR] WHERE ID = @ID AND ISDELETE = 0;.
        /// </summary>
        public static string SelectAcademicYearById {
            get {
                return ResourceManager.GetString("SelectAcademicYearById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM TBL_ACADEMICYEAR WHERE ISDELETE = 0 AND MAJORID=@MajorId;.
        /// </summary>
        public static string SelectAllAcademicyearByMajorId {
            get {
                return ResourceManager.GetString("SelectAllAcademicyearByMajorId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM TBL_MAJOR WHERE ISDELETE = 0 and UNIVERSITYID=@UniversityId;.
        /// </summary>
        public static string SelectAllMajorByUniversityId {
            get {
                return ResourceManager.GetString("SelectAllMajorByUniversityId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM TBL_STUDENT WHERE ISDELETE = 0;.
        /// </summary>
        public static string SelectAllStudent {
            get {
                return ResourceManager.GetString("SelectAllStudent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM TBL_UNIVERSITY WHERE ISDELETE = 0;.
        /// </summary>
        public static string SelectAllUniversity {
            get {
                return ResourceManager.GetString("SelectAllUniversity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM [TBL_MAJOR] WHERE ID = @ID AND ISDELETE = 0;.
        /// </summary>
        public static string SelectMajorById {
            get {
                return ResourceManager.GetString("SelectMajorById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM TBL_STUDENT WHERE ID = @Id;.
        /// </summary>
        public static string SelectStudentById {
            get {
                return ResourceManager.GetString("SelectStudentById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM TBL_STUDENT WHERE NRC = @NRC;.
        /// </summary>
        public static string SelectStudnetByNRC {
            get {
                return ResourceManager.GetString("SelectStudnetByNRC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM TBL_STUDENT WHERE NRC = @NRC AND ID &lt;&gt; @ID;.
        /// </summary>
        public static string SelectStudnetByNRCForUpdate {
            get {
                return ResourceManager.GetString("SelectStudnetByNRCForUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM TBL_STUDENT WHERE STUDENTNO = @StudentNo;.
        /// </summary>
        public static string SelectStudnetByStudentNo {
            get {
                return ResourceManager.GetString("SelectStudnetByStudentNo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM TBL_STUDENT WHERE STUDENTNO = @StudentNo AND ID &lt;&gt; @ID ;.
        /// </summary>
        public static string SelectStudnetByStudentNoForUpdate {
            get {
                return ResourceManager.GetString("SelectStudnetByStudentNoForUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM [TBL_UNIVERSITY] WHERE ID = @ID AND ISDELETE = 0;.
        /// </summary>
        public static string SelectUniversityById {
            get {
                return ResourceManager.GetString("SelectUniversityById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE TBL_STUDENT SET STUDENTNO = @STUDENTNO, NAME = @NAME, FATHERNAME = @FATHERNAME, NRC = @NRC, ADDRESS = @ADDRESS, PHONE = @PHONE, EMAIL = @EMAIL, GENDER = @GENDER, DOB = @DOB, UNIVERSITYID = @UNIVERSITYID, MAJORID = @MAJORID, ACADEMICYEARID = @ACADEMICYEARID, UPDATEDATE = @UPDATEDDATE, UPDATEDUSERID = @UPDATEDUSERID WHERE ID = @ID;.
        /// </summary>
        public static string UpdateUser {
            get {
                return ResourceManager.GetString("UpdateUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE TBL_USER SET DYNAMICKEY = @DYNAMICKEY, ISLOGIN = @ISLOGIN WHERE USERID = @USERID;.
        /// </summary>
        public static string User_UpdateKeyAndStatus {
            get {
                return ResourceManager.GetString("User_UpdateKeyAndStatus", resourceCulture);
            }
        }
    }
}
