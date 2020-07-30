<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_u.aspx.cs" Inherits="Escuela.Facultades.facultad_u" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


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
                Materias
            </td>
            <td>
                <asp:ListBox ID="ListBoxMaterias" CssClass="lista" Width="150px" SelectionMode="Multiple" runat="server"></asp:ListBox>
            </td>
        </tr>
		<tr>
			<td>
				Universidad
			</td>
			<td>
				<asp:DropDownList ID="ddlUniversidad" CssClass="lista" runat="server"></asp:DropDownList>
			</td>
		</tr>
        <tr>
            <td>Pais</td>
            <td>
                <asp:DropDownList ID="ddlPais" CssClass="lista" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
               
            </td>
        </tr>
        <tr>
            <td>Estado</td>
            <td>
                <asp:DropDownList ID="ddlEstado" CssClass="lista" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td>Ciudad</td>
            <td>
                <asp:DropDownList ID="ddlCiudad" CssClass="lista" runat="server"></asp:DropDownList>
                
            </td>
        </tr>
		<tr>
			<td>
				
			</td>
			<td>
				
			</td>
		</tr>
	</table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click"  />

     <script type="text/javascript">
        $(document).ready(function () {
    
                $("#MainContent_txtFecha").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1900:2010",
                dateFormat: "dd/mm/yy"
            });

            $(".lista").chosen();
        });

        var Manager = Sys.WebForms.PageRequestManager.getInstance();

        Manager.add_endRequest(function () {
             $(document).ready(function () {
    
                    $("#MainContent_txtFecha").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "1900:2010",
                        dateFormat: "dd/mm/yy"
                    });

                $(".lista").chosen();
            });

        });
</script>

</asp:Content>
