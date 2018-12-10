using PaoloCattaneo.DocumentMaker;
using PaoloCattaneo.DocumentMakerExample.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaoloCattaneo.DocumentMakerExample
{
    class Program
    {
        // External file references
        private static readonly string OUTPUT_MARKDOWN_FILE = "MD_output.md";
        private static readonly string OUTPUT_HTML_FILE = "HTML_output.html";
        private static readonly string INTRO_SECONDPARAGRAPH_FILE = "par2.txt";
        private static readonly string INTRO_ABOUT_FILE = "about.txt";
        private static readonly string EXAM_DETAIL_DESC_YAML = "desc_template.yml";

        #region Fake Data
        // Fake data objects
        private static Student John;
        private static List<Exam> Exams;
        private static List<ExamDetail> ExamsDetails;

        /// <summary>
        /// Creating some fake data
        /// </summary>
        private static void GetFakeData()
        {
            John = new Student();
            Exams = new List<Exam>() {              new Exam("Csharp development", "25/11/2018", 25),
                                                    new Exam("Python  development", "30/01/2019", 30),
                                                    new Exam("Machine Learning", "02/03/2019", 27)};
            ExamsDetails = new List<ExamDetail>()
            {
                new ExamDetail("Basics", "Advanced stuff", "Even more advanced stuff", "Why should I even use this?"),
                new ExamDetail("Yep, it's basically plain english", "Use Python with Big Data apps", "HowTo: Write a full app in a single line"),
                new ExamDetail("What?", "My own brain is not that hard to understand", "DIY Skynet")
            };
        }

        #endregion

        static void Main(string[] args)
        {
            GetFakeData();     //You will have real data at this point probably
            var document = AssembleDoc();   //Assemble a document
            Console.WriteLine("*********************\n* MARKDOWN RENDERED *\n*********************");
            string MDRendered = document.Render();  //Render() to obtain the MarkDown result
            Console.WriteLine(MDRendered);
            Console.WriteLine("******************\n* HTML RENDERED *\n******************");
            string HTMLRendered = document.RenderToHtml();  //RenderToHtml() to obtain the HTML result
            Console.WriteLine(HTMLRendered);

            document.RenderToMdFile(OUTPUT_MARKDOWN_FILE);  //Rendering to a MD output File
            document.RenderToHtmlFile(OUTPUT_HTML_FILE);    //Rendering to a HTML output File

            Console.ReadLine();
        }

        private static Document AssembleDoc()
        {
            //Create an empty Document
            var document = new Document();
            //With some style (I decided to embed the whole CSS but you can also just add a link)
            document.SetCss(new FileInfo("github-markdown.css"), embedded: true);

            //I need some advanced rendering so I must enable it
            document.EnableTable()          //this for table
                    .EnableExtraList();     //this for roman list, which is one of ExtraLists

            //I suggest you, to keep your code more organised, to split code where you generate
            //Sections in order to keep it modular and easier to understand
            document.AddSection(GetIntroSection())
                    .AddSection(GetUniversitySection());


            //Now our Document is ready!
            return document;
        }

        private static Section GetIntroSection()
        {
            //Add the first section (the introduction one)
            var introSec = new Section("DocumentMaker example");
            //Load and modify the first paragraph
            string par1 = "Welcome to this example of a document rendered using DocumentMaker C# library";
            par1 = TextFormat.ReplaceItalic(par1, "DocumentMaker");
            introSec.AddParagraph(par1);
            introSec.AddHr();
            //The second paragraph is loaded from a txt file because it is always the same
            //and it is quite long
            introSec.AddParagraph(new FileInfo(INTRO_SECONDPARAGRAPH_FILE));

            //Now let's create the subsection "About the author", of heading level 2
            var aboutSec = new Section("About the author", 2);
            introSec.AddSection(aboutSec);  //appending this subsection to the first one
            //Adding the paragraph, changing a substring in italic
            aboutSec.AddParagraph(TextFormat.ReplaceItalic(File.ReadAllText(INTRO_ABOUT_FILE),
                                    "DocumentMaker"));
            //The dot list with contact info will be manually assembled
            var contactInfos = new DotList();
            contactInfos.AddItem("Github profile: " + new DocLink("https://github.com/PaoloCattaneo92", "Github").Render()); //custom text
            contactInfos.AddItem("Mail: " + new MailToLink("paolo.cattaneo92@gmail.com").Render()); //this is used to correctly renders mailto addresses
            contactInfos.AddItem("Linkedin profile: " + new DocLink("https://www.linkedin.com/in/paolo-cattaneo-eng/", "Linkedin").Render());
            //Appending the dot list to the about section
            aboutSec.Add(contactInfos);
            return introSec;
        }

        private static Section GetUniversitySection()
        {
            //Now starting with the real example
            var mainSec = new Section($"Report for: {John.Name}");
            var persInfo = new Section("Personal Information", 2);
            mainSec.AddSection(persInfo);
            //Adding a pic with an external link (should works the same with an offline path)
            persInfo.Add(new Image("https://i.stack.imgur.com/l60Hf.png", "This should be a real pic", "Student photo", 100, 80));
            persInfo.AddParagraph();
            persInfo.AddQuote($"This is the profile pic of {John.Name}");
            //A paragraph with a on-a-fly italic word
            persInfo.AddParagraph("This personal information is automatically mapped in the List reading the properties of the " + TextFormat.Ital("Student") + " class");
            //Creating and auto-populating the Letterlist
            var autoLetterList = new NumberListAutoMap<Student>();
            autoLetterList.SetItem(John);
            //autoLetterList.Type = LetterType.LOWERCASE;
            persInfo.Add(autoLetterList);

            //Now to the auto-parsed Exams summary table
            var examsSummarySec = new Section("Exams summary", 2);
            mainSec.AddSection(examsSummarySec);
            examsSummarySec.AddParagraph("The following table is automatically mapped from the list of " + TextFormat.Ital("Exam"));
            var tableExams = new TableAutoMap<Exam>(Exams.ToArray());   //this table will auto detect property names
            tableExams.SetAlignement(TableAlignment.CENTER);    //this will set center for all the columns, you can set it for each every column
            examsSummarySec.Add(tableExams);

            //Last section: exams detail
            var examDetailsSec = new Section("Exams Detail", 2);
            mainSec.AddSection(examDetailsSec);
            examDetailsSec.AddParagraph("In this section we iterate over the list of exams and build a subsection of heading level 3 to have some details for each exam. I have also put an horizontal line between them.");
            var descTemplate = TemplateFromYaml.ReadFromYaml(EXAM_DETAIL_DESC_YAML);
            descTemplate.RenderMode = TemplateRenderMode.SINGLE;
            for (int i = 0; i < Exams.Count; i++)
            {
                var detailSec = new Section(Exams[i].Argument, 3);          //create subsection
                detailSec.AddParagraph("Chapters:");                        //adding a simple paragraph
                var chapList = new RomanList();                             //adding the chapter list
                foreach (string chapter in ExamsDetails[i].Chapters)
                {
                    chapList.AddItem(chapter);
                }
                detailSec.Add(chapList);
                descTemplate.ResultSingleID = Exams[i].Argument;    //choose the correct ID for the Result of the template
                detailSec.AddParagraph(descTemplate.Render());      //adding the rendered template as parahraph
                examDetailsSec.AddSection(detailSec);               //adding the subsection of level 3 to level 2
            }
            return mainSec;
        }
    }
}
