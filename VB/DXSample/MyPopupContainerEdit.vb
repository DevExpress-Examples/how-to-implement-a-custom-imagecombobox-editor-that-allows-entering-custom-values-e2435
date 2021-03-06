﻿Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository

Namespace DXSample
	<UserRepositoryItem("Register")> _
	Public Class RepositoryItemMyPopupContainerEdit
		Inherits RepositoryItemPopupContainerEdit
		Shared Sub New()
			Register()
		End Sub
		Private imageListBox As ImageListBoxControl
		Public Sub New()
			Dim popupControl As New PopupContainerControl()
			imageListBox = New ImageListBoxControl()
			imageListBox.Dock = System.Windows.Forms.DockStyle.Fill
			imageListBox.HotTrackItems = True
			imageListBox.HotTrackSelectMode = HotTrackSelectMode.SelectItemOnClick
			popupControl.Controls.Add(imageListBox)
			Me.PopupControl = popupControl
			TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
		End Sub
        <AttributeProvider(GetType(IListSource)), System.ComponentModel.DefaultValue(GetType(Object), Nothing), RefreshProperties(RefreshProperties.Repaint), Category("Data")> _
  Public Property DataSource() As Object
            Get
                Return imageListBox.DataSource
            End Get
            Set(ByVal value As Object)
                imageListBox.DataSource = value
            End Set
        End Property
		Protected Friend ReadOnly Property ListBox() As ImageListBoxControl
			Get
				Return imageListBox
			End Get
		End Property
        <Category(CategoryName.Appearance), System.ComponentModel.DefaultValue(GetType(Object), Nothing), TypeConverter(GetType(DevExpress.Utils.Design.ImageCollectionImagesConverter))> _
  Public Property ImageList() As Object
            Get
                Return imageListBox.ImageList
            End Get
            Set(ByVal value As Object)
                imageListBox.ImageList = value
            End Set
        End Property
		<Category(CategoryName.Data), DefaultValue(""), TypeConverter("DevExpress.XtraEditors.Design.DataMemberTypeConverter, " & AssemblyInfo.SRAssemblyEditorsDesign)> _
		Public Property ImageIndexMember() As String
			Get
				Return imageListBox.ImageIndexMember
			End Get
			Set(ByVal value As String)
				imageListBox.ImageIndexMember = value
			End Set
		End Property
		<Category(CategoryName.Data), DefaultValue(""), TypeConverter("DevExpress.XtraEditors.Design.DataMemberTypeConverter, " & AssemblyInfo.SRAssemblyEditorsDesign)> _
		Public Property DisplayMember() As String
			Get
				Return imageListBox.DisplayMember
			End Get
			Set(ByVal value As String)
				imageListBox.DisplayMember = value
			End Set
		End Property
		<Category(CategoryName.Data), DefaultValue(""), TypeConverter("DevExpress.XtraEditors.Design.DataMemberTypeConverter, " & AssemblyInfo.SRAssemblyEditorsDesign)> _
		Public Property ValueMember() As String
			Get
				Return imageListBox.ValueMember
			End Get
			Set(ByVal value As String)
				imageListBox.ValueMember = value
			End Set
		End Property
		Friend Const EditorName As String = "MyPopupContainerEdit"

		Public Shared Sub Register()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(MyPopupContainerEdit), GetType(RepositoryItemMyPopupContainerEdit), GetType(DevExpress.XtraEditors.ViewInfo.PopupContainerEditViewInfo), New DevExpress.XtraEditors.Drawing.ButtonEditPainter(), True, CType(Nothing, System.Drawing.Image), GetType(DevExpress.Accessibility.PopupEditAccessible)))
		End Sub
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return EditorName
			End Get
		End Property
		Public Overrides Sub Assign(ByVal item As RepositoryItem)
			MyBase.Assign(item)
			If TypeOf item Is RepositoryItemMyPopupContainerEdit Then
				imageListBox = (CType(item, RepositoryItemMyPopupContainerEdit)).ListBox
			End If
		End Sub
	End Class

	Public Class MyPopupContainerEdit
		Inherits PopupContainerEdit
		Shared Sub New()
			RepositoryItemMyPopupContainerEdit.Register()
		End Sub

		Public Sub New()
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemMyPopupContainerEdit.EditorName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemMyPopupContainerEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemMyPopupContainerEdit)
			End Get
		End Property
		Public Overrides Sub ShowPopup()
			Properties.ListBox.SelectedValue = EditValue
			MyBase.ShowPopup()
		End Sub
		Private Sub ListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			EditValue = Properties.ListBox.SelectedValue
		End Sub
		Protected Overrides Sub OnPopupShown()
			MyBase.OnPopupShown()
			AddHandler Properties.ListBox.SelectedIndexChanged, AddressOf ListBox_SelectedIndexChanged
			AddHandler Properties.ListBox.MouseDown, AddressOf ListBox_MouseDown
		End Sub

		Private Sub ListBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
			ClosePopup()
			EditValue = Properties.ListBox.SelectedValue
		End Sub
		Public Overrides Overloads Sub ClosePopup()
			MyBase.ClosePopup()
			RemoveHandler Properties.ListBox.SelectedIndexChanged, AddressOf ListBox_SelectedIndexChanged
			RemoveHandler Properties.ListBox.MouseDown, AddressOf ListBox_MouseDown
		End Sub
	End Class
End Namespace
