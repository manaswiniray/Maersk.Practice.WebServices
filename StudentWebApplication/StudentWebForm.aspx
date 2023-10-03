<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentWebForm.aspx.cs" Inherits="StudentWebApplication.StudentWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Student Portal</h1>
            <br />

            <asp:Label ID="labelMessage" runat="server"></asp:Label>

            <br />  <br /> <br />

            <asp:TextBox id="textId" runat="server" placeholder="Student Id" ></asp:TextBox>
            <asp:TextBox id="textName" runat="server" placeholder="Student Name" ></asp:TextBox>
            <asp:TextBox id="textAge" runat="server" placeholder="Student Age" ></asp:TextBox>

            <br /> <br /> <br />

            <asp:Button  id="addStudent" runat="server" OnClick="addStudent_Click" Text="Add Student" />
            <asp:Button  id="getStudentById" runat="server" OnClick="getStudentById_Click" Text="Get Student By Id" />
            <asp:Button  id="getAllStudents" runat="server" OnClick="getAllStudents_Click" Text="Get All Students" />
            <asp:Button  id="updateStudent" runat="server" OnClick="updateStudent_Click" Text="Update Student" />
            <asp:Button  id="removeStudent" runat="server" OnClick="removeStudent_Click" Text="Remove Student" />

        </div>
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="true"></asp:GridView>
    </form>
</body>
</html>
