using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using Ink.Runtime;
using FMOD;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Dialog_end : MonoBehaviour
{
    public DialogManager DialogManager;

    // just to check if the dialog system is not blocking (so we can animate, play VFX, etc)
    public float test_time;

    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public Story story;

    private void Awake()
    {
        if (DialogManager == null)
        {
            DialogManager = GameObject.FindObjectOfType<DialogManager>();
        }

        if (!story && inkJSONAsset != null)
        {
            story = new Story(inkJSONAsset.text);
        }
    }

    void Start()
    {
        StartStory();
    }

    void Update()
    {
        test_time = Time.time;
    }

    // Creates a new Story object with the compiled story which we can then play!
    void StartStory()
    {
        if (story)
        {
            story.variablesState["dog_names"] = Player_data_mgr.Instance.get_adopted_dog_names();
        }

        // if (OnCreateStory != null) OnCreateStory(story);
        RefreshView();
    }

    void EndStory()
    {
        if (story)
        {
            var back_to_sel_scene = (int)story.variablesState["back_to_selection"];
            if (back_to_sel_scene > 0)
            {
                Story_selection_mgr.Instance.Reset_round(Day_enum.day_1);
                Story_selection_mgr.Instance.Scene_transition("Scene_transition", "Scene_selection",
                                                              Day_txt_display.day_1);
            }
            else
            {
                SceneManager.LoadSceneAsync("Scene_UI_TitleScreen");
            }
        }
        else
        {
            SceneManager.LoadSceneAsync("Scene_UI_TitleScreen");
        }
    }

    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is
    // finished!
    void RefreshView()
    {
        // Remove all the UI on screen
        // RemoveChildren();

        var dialogTexts = new List<DialogData>();

        DialogData currentDialog = null;

        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            // CreateContentView(text);

            // Find speaker name from tags
            var tags = story.currentTags;
            var tag_name = Find_speaker_name(tags);

            // var tag_emote = Find_emote_name(tags);
            if (tag_name == "Me")
            {
                var tag_emote = Player_data_mgr.Instance.get_emote_code_for_player_picture();
                text = tag_emote + text;
            }

            currentDialog = new DialogData(text, tag_name, null /*() => OnClickChoiceButton()*/);
            dialogTexts.Add(currentDialog);
        }

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];

                string text = choice.text.Trim();
                currentDialog.SelectList.Add(choice.index.ToString(), text);

                // Button button = CreateChoiceView(choice.text.Trim());
                //  Tell the button what to do when we press it
                // button.onClick.AddListener(delegate {
                //	OnClickChoiceButton(choice);
                // });
            }

            currentDialog.Callback = () => Check_Choice();

            // dialogTexts.Add(currentDialog);
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            dialogTexts.Add(new DialogData("See you around", "Blank", () => EndStory()));
        }

        DialogManager.Show(dialogTexts);
    }

    private void Check_Choice()
    {
        int index = int.Parse(DialogManager.Result);
        story.ChooseChoiceIndex(index);
        RefreshView();
    }

    private string Find_speaker_name(List<string> tags)
    {
        string tag_name = null;
        if (tags.Count > 0)
        {
            tag_name = tags.Find(x => x.Contains("Name_"));
            if (tag_name != null && tag_name.Length > 0)
            {
                tag_name = tag_name.Remove(0, "Name_".Length);
            }
        }

        if (tag_name == null)
            return "Blank";

        return tag_name;
    }

    private string Find_emote_name(List<string> tags)
    {
        // disable Emote to prevent crash
        return "";

        string tag_name = null;
        if (tags.Count > 0)
        {
            tag_name = tags.Find(x => x.Contains("Emote_"));
            if (tag_name != null && tag_name.Length > 0)
            {
                tag_name = tag_name.Remove(0, "Emote_".Length);
            }
        }

        if (tag_name == null)
            return "";

        return "/emote:" + tag_name + "/";
    }
}
