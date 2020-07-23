<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_s.aspx.cs" Inherits="Escuela.Facultades.facultad_s" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<asp:GridView ID="grd_Facultades" AutoGenerateColumns="false" runat="server" OnRowCommand="grd_Facultades_RowCommand">
	<columns>
			<asp:TemplateField>
				<ItemTemplate>
					<asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Imagenes/lapiz.png" Height="20px" Width="20px" CommandName="Editar" CommandArgument='<%# Eval("ID_Facultad") %>'/>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<ItemTemplate>
					<asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/contenedor.png" Height="20px" Width="20px" CommandName="Eliminar" CommandArgument='<%# Eval("ID_Facultad") %>'/>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField HeaderText="ID Facultad" DataField="ID_Facultad"/>
			<asp:BoundField HeaderText="Codigo" DataField="codigo"/>
			<asp:BoundField HeaderText="Nombre" DataField="nombre"/>
			<asp:BoundField HeaderText="Fecha de Creacion" DataField="fechaCreacion" DataFormatString="{0:dd/MM/yyyy}" />
			<asp:BoundField HeaderText="Universidad" DataField="universidad" />
            <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" />

		</columns>
		</asp:GridView>
</asp:Content>
