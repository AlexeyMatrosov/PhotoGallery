﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("PhotoGallery.Domain", "FK_Uploads_Photos", "Photos", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(PhotoGallery.Domain.Photo), "Uploads", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(PhotoGallery.Domain.Upload), true)]
[assembly: EdmRelationshipAttribute("PhotoGallery.Domain", "FK_Users_Roles", "Roles", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(PhotoGallery.Domain.Role), "Users", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(PhotoGallery.Domain.User), true)]
[assembly: EdmRelationshipAttribute("PhotoGallery.Domain", "FK_Uploads_Users", "Users", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(PhotoGallery.Domain.User), "Uploads", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(PhotoGallery.Domain.Upload), true)]

#endregion

namespace PhotoGallery.Domain
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class PhotoGalleryEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new PhotoGalleryEntities object using the connection string found in the 'PhotoGalleryEntities' section of the application configuration file.
        /// </summary>
        public PhotoGalleryEntities() : base("name=PhotoGalleryEntities", "PhotoGalleryEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new PhotoGalleryEntities object.
        /// </summary>
        public PhotoGalleryEntities(string connectionString) : base(connectionString, "PhotoGalleryEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new PhotoGalleryEntities object.
        /// </summary>
        public PhotoGalleryEntities(EntityConnection connection) : base(connection, "PhotoGalleryEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Photo> Photos
        {
            get
            {
                if ((_Photos == null))
                {
                    _Photos = base.CreateObjectSet<Photo>("Photos");
                }
                return _Photos;
            }
        }
        private ObjectSet<Photo> _Photos;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Role> Roles
        {
            get
            {
                if ((_Roles == null))
                {
                    _Roles = base.CreateObjectSet<Role>("Roles");
                }
                return _Roles;
            }
        }
        private ObjectSet<Role> _Roles;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Upload> Uploads
        {
            get
            {
                if ((_Uploads == null))
                {
                    _Uploads = base.CreateObjectSet<Upload>("Uploads");
                }
                return _Uploads;
            }
        }
        private ObjectSet<Upload> _Uploads;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Photos EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPhotos(Photo photo)
        {
            base.AddObject("Photos", photo);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Roles EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToRoles(Role role)
        {
            base.AddObject("Roles", role);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Uploads EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUploads(Upload upload)
        {
            base.AddObject("Uploads", upload);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PhotoGallery.Domain", Name="Photo")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Photo : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Photo object.
        /// </summary>
        /// <param name="photoID">Initial value of the PhotoID property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="description">Initial value of the Description property.</param>
        /// <param name="uploadDate">Initial value of the UploadDate property.</param>
        /// <param name="amountRating">Initial value of the AmountRating property.</param>
        /// <param name="numberRating">Initial value of the NumberRating property.</param>
        public static Photo CreatePhoto(global::System.Int32 photoID, global::System.String name, global::System.String description, global::System.DateTime uploadDate, global::System.Decimal amountRating, global::System.Int32 numberRating)
        {
            Photo photo = new Photo();
            photo.PhotoID = photoID;
            photo.Name = name;
            photo.Description = description;
            photo.UploadDate = uploadDate;
            photo.AmountRating = amountRating;
            photo.NumberRating = numberRating;
            return photo;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PhotoID
        {
            get
            {
                return _PhotoID;
            }
            set
            {
                if (_PhotoID != value)
                {
                    OnPhotoIDChanging(value);
                    ReportPropertyChanging("PhotoID");
                    _PhotoID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PhotoID");
                    OnPhotoIDChanged();
                }
            }
        }
        private global::System.Int32 _PhotoID;
        partial void OnPhotoIDChanging(global::System.Int32 value);
        partial void OnPhotoIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime UploadDate
        {
            get
            {
                return _UploadDate;
            }
            set
            {
                OnUploadDateChanging(value);
                ReportPropertyChanging("UploadDate");
                _UploadDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UploadDate");
                OnUploadDateChanged();
            }
        }
        private global::System.DateTime _UploadDate;
        partial void OnUploadDateChanging(global::System.DateTime value);
        partial void OnUploadDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal AmountRating
        {
            get
            {
                return _AmountRating;
            }
            set
            {
                OnAmountRatingChanging(value);
                ReportPropertyChanging("AmountRating");
                _AmountRating = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AmountRating");
                OnAmountRatingChanged();
            }
        }
        private global::System.Decimal _AmountRating;
        partial void OnAmountRatingChanging(global::System.Decimal value);
        partial void OnAmountRatingChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 NumberRating
        {
            get
            {
                return _NumberRating;
            }
            set
            {
                OnNumberRatingChanging(value);
                ReportPropertyChanging("NumberRating");
                _NumberRating = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("NumberRating");
                OnNumberRatingChanged();
            }
        }
        private global::System.Int32 _NumberRating;
        partial void OnNumberRatingChanging(global::System.Int32 value);
        partial void OnNumberRatingChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PhotoGallery.Domain", "FK_Uploads_Photos", "Uploads")]
        public EntityCollection<Upload> Uploads
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Upload>("PhotoGallery.Domain.FK_Uploads_Photos", "Uploads");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Upload>("PhotoGallery.Domain.FK_Uploads_Photos", "Uploads", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PhotoGallery.Domain", Name="Role")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Role : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Role object.
        /// </summary>
        /// <param name="roleID">Initial value of the RoleID property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static Role CreateRole(global::System.Int32 roleID, global::System.String name)
        {
            Role role = new Role();
            role.RoleID = roleID;
            role.Name = name;
            return role;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 RoleID
        {
            get
            {
                return _RoleID;
            }
            set
            {
                if (_RoleID != value)
                {
                    OnRoleIDChanging(value);
                    ReportPropertyChanging("RoleID");
                    _RoleID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("RoleID");
                    OnRoleIDChanged();
                }
            }
        }
        private global::System.Int32 _RoleID;
        partial void OnRoleIDChanging(global::System.Int32 value);
        partial void OnRoleIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PhotoGallery.Domain", "FK_Users_Roles", "Users")]
        public EntityCollection<User> Users
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<User>("PhotoGallery.Domain.FK_Users_Roles", "Users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<User>("PhotoGallery.Domain.FK_Users_Roles", "Users", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PhotoGallery.Domain", Name="Upload")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Upload : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Upload object.
        /// </summary>
        /// <param name="uploadID">Initial value of the UploadID property.</param>
        /// <param name="userID">Initial value of the UserID property.</param>
        /// <param name="photoID">Initial value of the PhotoID property.</param>
        public static Upload CreateUpload(global::System.Int32 uploadID, global::System.Int32 userID, global::System.Int32 photoID)
        {
            Upload upload = new Upload();
            upload.UploadID = uploadID;
            upload.UserID = userID;
            upload.PhotoID = photoID;
            return upload;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 UploadID
        {
            get
            {
                return _UploadID;
            }
            set
            {
                if (_UploadID != value)
                {
                    OnUploadIDChanging(value);
                    ReportPropertyChanging("UploadID");
                    _UploadID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UploadID");
                    OnUploadIDChanged();
                }
            }
        }
        private global::System.Int32 _UploadID;
        partial void OnUploadIDChanging(global::System.Int32 value);
        partial void OnUploadIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                OnUserIDChanging(value);
                ReportPropertyChanging("UserID");
                _UserID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UserID");
                OnUserIDChanged();
            }
        }
        private global::System.Int32 _UserID;
        partial void OnUserIDChanging(global::System.Int32 value);
        partial void OnUserIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PhotoID
        {
            get
            {
                return _PhotoID;
            }
            set
            {
                OnPhotoIDChanging(value);
                ReportPropertyChanging("PhotoID");
                _PhotoID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PhotoID");
                OnPhotoIDChanged();
            }
        }
        private global::System.Int32 _PhotoID;
        partial void OnPhotoIDChanging(global::System.Int32 value);
        partial void OnPhotoIDChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PhotoGallery.Domain", "FK_Uploads_Photos", "Photos")]
        public Photo Photos
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Photo>("PhotoGallery.Domain.FK_Uploads_Photos", "Photos").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Photo>("PhotoGallery.Domain.FK_Uploads_Photos", "Photos").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Photo> PhotosReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Photo>("PhotoGallery.Domain.FK_Uploads_Photos", "Photos");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Photo>("PhotoGallery.Domain.FK_Uploads_Photos", "Photos", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PhotoGallery.Domain", "FK_Uploads_Users", "Users")]
        public User Users
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("PhotoGallery.Domain.FK_Uploads_Users", "Users").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("PhotoGallery.Domain.FK_Uploads_Users", "Users").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<User> UsersReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("PhotoGallery.Domain.FK_Uploads_Users", "Users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<User>("PhotoGallery.Domain.FK_Uploads_Users", "Users", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PhotoGallery.Domain", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new User object.
        /// </summary>
        /// <param name="userID">Initial value of the UserID property.</param>
        /// <param name="userName">Initial value of the UserName property.</param>
        /// <param name="email">Initial value of the Email property.</param>
        /// <param name="password">Initial value of the Password property.</param>
        /// <param name="access">Initial value of the Access property.</param>
        public static User CreateUser(global::System.Int32 userID, global::System.String userName, global::System.String email, global::System.String password, global::System.Int32 access)
        {
            User user = new User();
            user.UserID = userID;
            user.UserName = userName;
            user.Email = email;
            user.Password = password;
            user.Access = access;
            return user;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                if (_UserID != value)
                {
                    OnUserIDChanging(value);
                    ReportPropertyChanging("UserID");
                    _UserID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UserID");
                    OnUserIDChanged();
                }
            }
        }
        private global::System.Int32 _UserID;
        partial void OnUserIDChanging(global::System.Int32 value);
        partial void OnUserIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                OnUserNameChanging(value);
                ReportPropertyChanging("UserName");
                _UserName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UserName");
                OnUserNameChanged();
            }
        }
        private global::System.String _UserName;
        partial void OnUserNameChanging(global::System.String value);
        partial void OnUserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }
        private global::System.String _Password;
        partial void OnPasswordChanging(global::System.String value);
        partial void OnPasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Access
        {
            get
            {
                return _Access;
            }
            set
            {
                OnAccessChanging(value);
                ReportPropertyChanging("Access");
                _Access = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Access");
                OnAccessChanged();
            }
        }
        private global::System.Int32 _Access;
        partial void OnAccessChanging(global::System.Int32 value);
        partial void OnAccessChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PhotoGallery.Domain", "FK_Users_Roles", "Roles")]
        public Role Roles
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Role>("PhotoGallery.Domain.FK_Users_Roles", "Roles").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Role>("PhotoGallery.Domain.FK_Users_Roles", "Roles").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Role> RolesReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Role>("PhotoGallery.Domain.FK_Users_Roles", "Roles");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Role>("PhotoGallery.Domain.FK_Users_Roles", "Roles", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PhotoGallery.Domain", "FK_Uploads_Users", "Uploads")]
        public EntityCollection<Upload> Uploads
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Upload>("PhotoGallery.Domain.FK_Uploads_Users", "Uploads");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Upload>("PhotoGallery.Domain.FK_Uploads_Users", "Uploads", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
