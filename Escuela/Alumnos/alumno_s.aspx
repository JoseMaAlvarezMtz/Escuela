<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_s.aspx.cs" Inherits="Escuela.Alumnos.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<asp:GridView ID="grd_Alumnos" autogeneratecolumns="false" runat="server" OnRowCommand="grd_Alumnos_RowCommand">

		<Columns>
			<asp:TemplateField>
				<ItemTemplate>
					<asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Imagenes/lapiz.png" Height="20px" Width="20px" CommandName="Editar" CommandArgument='<%# Eval("matricula") %>'/>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<ItemTemplate>
					<asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/contenedor.png" Height="20px" Width="20px" CommandName="Eliminar" CommandArgument='<%# Eval("matricula") %>'/>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField HeaderText="Matricula" DataField="matricula"/>
			<asp:BoundField HeaderText="Nombre" DataField="nombre"/>
			<asp:BoundField HeaderText="Fecha de Nacimiento" DataField="fechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" />
			<asp:BoundField HeaderText="Semestre" DataField="semestre"/>
			<asp:BoundField HeaderText="Facultad" DataField="nombrefacultad" />

		</Columns>

	</asp:GridView>

</asp:Content>
