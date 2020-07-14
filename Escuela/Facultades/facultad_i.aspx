<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_i.aspx.cs" Inherits="Escuela.Facultades.facultad_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<table>
		<tr>
			<td>
				Codigo
			</td>
			<td>
				<asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				Nombre
			</td>
			<td>
				<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				Fecha de Creacion
			</td>
			<td>
				<asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				Universidad
			</td>
			<td>
				<asp:DropDownList ID="ddlUniversidad" runat="server"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
				
			</td>
			<td>
				<asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
			</td>
		</tr>
	</table>

</asp:Content>
