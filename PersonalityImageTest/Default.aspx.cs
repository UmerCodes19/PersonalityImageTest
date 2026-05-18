using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace PersonalityImageTest
{
    public partial class Default : System.Web.UI.Page
    {
        private static readonly List<ImagePersonalityOption> Options = new List<ImagePersonalityOption>
        {
            new ImagePersonalityOption("forest", "Forest Path", "Images/forest.svg", "The Calm Explorer",
                "You are thoughtful, observant, and patient. You prefer meaningful experiences and usually notice details that other people miss."),
            new ImagePersonalityOption("ocean", "Ocean Wave", "Images/ocean.svg", "The Free Spirit",
                "You are adaptable, imaginative, and open-minded. You enjoy fresh ideas and feel energized when life gives you room to move."),
            new ImagePersonalityOption("city", "City Lights", "Images/city.svg", "The Ambitious Planner",
                "You are goal-oriented, practical, and confident. You like progress, clear targets, and situations where your effort produces visible results."),
            new ImagePersonalityOption("mountain", "Mountain Peak", "Images/mountain.svg", "The Determined Achiever",
                "You are resilient, focused, and independent. Challenges motivate you, and you are willing to work steadily for long-term success."),
            new ImagePersonalityOption("sunrise", "Golden Sunrise", "Images/sunrise.svg", "The Optimistic Starter",
                "You bring hopeful energy to new situations. You enjoy beginnings, encourage others, and often look for the positive path forward."),
            new ImagePersonalityOption("library", "Quiet Library", "Images/library.svg", "The Deep Thinker",
                "You value knowledge, reflection, and careful decisions. People may rely on you when they need a balanced and well-reasoned view.")
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindImages();
            }
        }

        protected void ImageRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != "SelectImage")
            {
                return;
            }

            string selectedKey = e.CommandArgument.ToString();
            ImagePersonalityOption selectedOption = Options.Find(option => option.Key == selectedKey);

            if (selectedOption == null)
            {
                return;
            }

            ResultTitleLiteral.Text = selectedOption.ResultTitle;
            ResultDescriptionLiteral.Text = selectedOption.ResultDescription;
            ResultPanel.Visible = true;
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            ResultPanel.Visible = false;
            ResultTitleLiteral.Text = string.Empty;
            ResultDescriptionLiteral.Text = string.Empty;
            BindImages();
        }

        private void BindImages()
        {
            ImageRepeater.DataSource = Options;
            ImageRepeater.DataBind();
        }

        private class ImagePersonalityOption
        {
            public ImagePersonalityOption(string key, string title, string imageUrl, string resultTitle, string resultDescription)
            {
                Key = key;
                Title = title;
                ImageUrl = imageUrl;
                ResultTitle = resultTitle;
                ResultDescription = resultDescription;
            }

            public string Key { get; private set; }
            public string Title { get; private set; }
            public string ImageUrl { get; private set; }
            public string ResultTitle { get; private set; }
            public string ResultDescription { get; private set; }
        }
    }
}
