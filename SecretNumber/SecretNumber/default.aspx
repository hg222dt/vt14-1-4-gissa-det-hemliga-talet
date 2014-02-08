<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SecretNumber.WebForm1" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hemliga talet!</title>
    <link rel="stylesheet" href="Content/Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%-- Summerar och skriver ut felmeddelanden överst på sidan --%>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

        <%-- Skriver ut initierande instruktion --%>
        <asp:Label ID="InstructionText" runat="server" Text="Ange ett tal mellan 1-100: "></asp:Label>

        <%-- Inmatningsfält för gissningar --%>
        <asp:TextBox ID="GuessInput" runat="server"></asp:TextBox>

        <%-- Validatorer --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="None" runat="server" ErrorMessage="Fältet får inte lämnas tomt!" ControlToValidate="GuessInput"/>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Du måste mata in ett heltal mellan 1 och 100" Type="Integer" MinimumValue="1" MaximumValue="100" Display="None" ControlToValidate="GuessInput" />
        
        <%-- Knapp för gissningar --%>
        <asp:Button ID="GuessButton" runat="server" Text="Gissa!" OnClick="GuessButton_Click" />
        <br />

        <%-- Textfält där gissade nummer skrivs ut --%>
        <asp:Label ID="GuessedNumbTxt" runat="server"></asp:Label>
        <br />

        <%-- Label där utfall skrivs ut --%>
        <asp:Label ID="ResultTxt" runat="server"></asp:Label>
        <br />

        <%-- Labe där slutligt resultat skriv ut om det inte går att göra fler gissningar --%>
        <asp:Label ID="FinalResultTxt" runat="server"></asp:Label>
        <br />

        <%-- Knapp för att spela nytt spel --%>
        <asp:Button ID="NewGameButton" runat="server" Text="Nytt spel!" OnClick="NewGameButton_Click" Visible="false" />
    </div>
    </form>
    <script type="text/javascript">
        <%-- Sätter fous och markerar i input-fältet --%>
        document.getElementById("GuessInput").focus();
        document.getElementById("GuessInput").select();
    </script>
</body>
</html>
