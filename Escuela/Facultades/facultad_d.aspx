<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_d.aspx.cs" Inherits="Escuela.Facultades.facultad_d" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<table>
		<tr>
			<td>
				ID Facultad
			</td>
			<td>
				<asp:Label ID="lblID_Facultad" runat="server" Text=""></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				Codigo
			</td>
			<td>
				<asp:Label ID="lblCodigo" runat="server" Text=""></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				Nombre
			</td>
			<td>
				<asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				Fecha de Creacion
			</td>
			<td>
				<asp:Label ID="lblFecha" runat="server" Text=""></asp:Label>
			</td>
		</tr>
		
		<tr>
			<td>
				Universidad
			</td>
			<td>
				<asp:DropDownList ID="ddlUniversidad" runat="server" Enabled="false"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
				
			</td>
			<td>
				<asp:Button ID="btnBorrar" runat="server" Text="Borrar" OnClick="btnBorrar_Click"   />
			</td>
		</tr>
	</table>


</asp:Content>
