<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_i.aspx.cs" Inherits="Escuela.Alumnos.alumno_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<table>
		<tr>
			<td>
				Matricula
			</td>
			<td>
				<asp:TextBox ID="txtMatricula" MaxLength="8" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_matricula" runat="server" ErrorMessage="La matricula es requerida" ControlToValidate="txtMatricula" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_matricula" runat="server" Display="Dynamic" ControlToValidate="txtMatricula" ValidationExpression="^[0-9]+$" ErrorMessage="Solo se aceptan numeros enteros" ValidationGroup="vlg1"></asp:RegularExpressionValidator>
			</td>
		</tr>
		<tr>
			<td>
				Nombre
			</td>
			<td>
				<asp:TextBox ID="txtNombre" MaxLength="100" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" Display="Dynamic" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
			</td>
		</tr>
		<tr>
			<td>
				Fecha de Nacimiento
			</td>
			<td>
				<asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" Display="Dynamic" ErrorMessage="La fecha es requerida" ControlToValidate="txtFechaNacimiento" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cv_fecha" runat="server" ErrorMessage="El formato es incorrecto (dd/mm/yyyy) o (mm/dd/yyy)" ControlToValidate="txtFechaNacimiento" Type="Date" Operator="DataTypeCheck" ValidationGroup="vlg1"></asp:CustomValidator>
			</td>
		</tr>
		<tr>
			<td>
				Semestre
			</td>
			<td>
				<asp:TextBox ID="txtSemestre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_semestre" runat="server" Display="Dynamic" ErrorMessage="El semestre es requerido" ControlToValidate="txtSemestre" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rv_semestre" runat="server" ErrorMessage="El semestre debe ser un valor entero entre 1 y 12" ControlToValidate="txtSemestre" ValidationGroup="vlg1" Type="Integer" MinimumValue="1" MaximumValue="12"></asp:RangeValidator>
			</td>
		</tr>
		<tr>
			<td>
				Facultad
			</td>
			<td>
				<asp:DropDownList ID="ddlFacultad" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_facultad" runat="server" InitialValue="0" ErrorMessage="La facultad es requerida" Display="Dynamic" ControlToValidate="ddlFacultad" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
			</td>
		</tr>
		<tr>
			<td>
				
			</td>
			<td>
				<asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ValidationGroup="vlg1"/>
			</td>
		</tr>
	</table>
    <asp:GridView ID="grd_Alumnos" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Matricula" DataField="matricula"/>
            <asp:BoundField  HeaderText="Nombre" DataField="nombre"/>
        </Columns>
    </asp:GridView>
</asp:Content>
