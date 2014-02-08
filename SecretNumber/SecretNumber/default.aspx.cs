using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecretNumber
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Model.SecretNumber Game
        {
            get
            {
                if (Session["game"] == null)
                {
                    Session["game"] = new Model.SecretNumber();
                    return (Model.SecretNumber)Session["game"];
                }
                else
                {
                    return (Model.SecretNumber)Session["game"];
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {   
            if(IsValid)
            {
                //Tar in gissning från textbox
                int guess = int.Parse(GuessInput.Text);

                Model.Outcome status = Game.MakeGuess(guess);

                if(status == Model.Outcome.Low)
                {
                    ResultTxt.Text = "Gissningen var för låg";
                }
                else if(status == Model.Outcome.High)
                {
                    ResultTxt.Text = "Gissningen var för hög";
                }
                else if(status == Model.Outcome.Correct)
                {
                    ResultTxt.Text = String.Format("Grattis du gissade på rätt tal! Det tog dig {0} gissningar!", Game.Count);

                    //Lås fält.
                    GuessInput.Enabled = false;
                    GuessButton.Enabled = false;
                }
                else if(status == Model.Outcome.PreviousGuess)
                {
                    ResultTxt.Text = "Gissningen var på ett tidigare gissat tal. Gör om gissningen";
                }

                if(status == Model.Outcome.NoMoreGuesses)
                {
                    FinalResultTxt.Text = String.Format("Du har tyvär inga gissningar kvar! Det hemliga talet var: {0}", Game.Number);

                    //Lås fält.
                    GuessInput.Enabled = false;
                    GuessButton.Enabled = false;
                }

                string str = "Gjorda gissningar: ";

                //Skriv ut alla gissade tal
                foreach(int i in Game.PreviousGuesses)
                {
                    str += string.Format("{0} ", i.ToString());
                }

                //Gör sen så att sista numret visas fetstilat för sig själv.
                GuessedNumbTxt.Text = str;   
            }
        }

        protected void NewGameButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("default.aspx");
        }
    }
}