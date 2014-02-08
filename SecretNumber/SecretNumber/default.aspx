<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SecretNumber.WebForm1" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/styles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Label ID="InstructionText" runat="server" Text="Ange ett tal mellan 1-100: "></asp:Label>
        <asp:TextBox ID="GuessInput" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" runat="server" ErrorMessage="Fältet får inte lämnas tomt!" ControlToValidate="GuessInput"/>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" Type="Integer" MinimumValue="1" MaximumValue="100" Display="None" ControlToValidate="GuessInput" />
        <asp:Button ID="GuessButton" runat="server" Text="Gissa!" OnClick="GuessButton_Click" />
        <asp:Label ID="GuessedNumbTxt" runat="server"></asp:Label>
        <asp:Label ID="LastGuessedTxt" runat="server"></asp:Label>
        <asp:Image ID="StatusImage" runat="server" />
        <asp:Label ID="ResultTxt" runat="server"></asp:Label>
        <asp:Label ID="FinalResultTxt" runat="server"></asp:Label>
        <asp:Button ID="NewGameButton" runat="server" Text="Nytt spel!" OnClick="NewGameButton_Click" />
    </div>
    </form>
    <script type="text/javascript">
        document.getElementById("GuessInput").focus();
        document.getElementById("GuessInput").select();
    </script>
</body>
</html>
