<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_i.aspx.cs" Inherits="Escuela.Facultades.facultad_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

	<table>
		<tr>
			<td>
				Codigo
			</td>
			<td>
				<asp:TextBox ID="txtCodigo" MaxLength="6" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ErrorMessage="El codigo es requerido" Display="Dynamic" ControlToValidate="txtCodigo" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCodigo" runat="server" ValidationExpression="^([A-Z]{4}[0-9]{2})$" ControlToValidate="txtCodigo" Display="Dynamic" ValidationGroup="vlg1" ErrorMessage="El formato de codigo es invalido (AAAA00)"></asp:RegularExpressionValidator>
			</td>
		</tr>
		<tr>
			<td>
				Nombre
			</td>
			<td>
				<asp:TextBox ID="txtNombre" MaxLength="100" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="El nombre es requerido" Display="Dynamic" ControlToValidate="txtNombre" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
			</td>
		</tr>
		<tr>
			<td>
				Fecha de Creacion
			</td>
			<td>
				<asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ErrorMessage="La fecha es requerida" Display="Dynamic" ControlToValidate="txtFecha" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvFecha" runat="server" ErrorMessage="Formato invalido ingresar en formato (dd/mm/yyyy)" ControlToValidate="txtFecha" Type="Date" Operator="DateTypeCheck" ValidationGroup="vlg1"></asp:CustomValidator>
                <asp:RegularExpressionValidator ID="revFecha" ControlToValidate="txtFecha" ValidationExpression="^([0-9]{2}/[0-9]{2}/[0-9]{4})$" runat="server" Display="Dynamic" ValidationGroup="vlg1" ErrorMessage="Formato invalido favor de ingresar con el formato (dd/mm/yyyy)"></asp:RegularExpressionValidator>
			</td>
		</tr>
		<tr>
			<td>
				Universidad
			</td>
			<td>
				<asp:DropDownList ID="ddlUniversidad" CssClass="lista" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvUniversidad" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlUniversidad" ValidationGroup="vlg1" ErrorMessage="La universidad es requerida"></asp:RequiredFieldValidator>
			</td>
		</tr>
        <tr>
            <td>Pais</td>
            <td>
                <asp:DropDownList ID="ddlPais" CssClass="lista" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvPais" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlPais" ValidationGroup="vlg1" ErrorMessage="El pais es requerido"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Estado</td>
            <td>
                <asp:DropDownList ID="ddlEstado" CssClass="lista" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEstado" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlEstado" ValidationGroup="vlg1" ErrorMessage="El estado es requerido"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Ciudad</td>
            <td>
                <asp:DropDownList ID="ddlCiudad" CssClass="lista" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCiudad" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlCiudad" ValidationGroup="vlg1" ErrorMessage="La ciudad es requerida"></asp:RequiredFieldValidator>
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
				
			</td>
			<td>
				
			</td>
		</tr>
	</table>
            
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ValidationGroup="vlg1" />

    <asp:GridView ID="grvFacultades" AutoGenerateColumns="false" runat="server">
        <Columns>
            
            <asp:BoundField HeaderText="Codigo" DataField="codigo"/>
            <asp:BoundField HeaderText="Nombre" DataField="nombre"/> 
        
        </Columns>
    </asp:GridView>

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
