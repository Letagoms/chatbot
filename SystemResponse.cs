using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;


namespace Part1
{
    public class SystemResponse
    {
        //filtered words array list
        //key words in dictionary array list
        private System.Collections.ArrayList filteredWords;
        private System.Collections.ArrayList keyWordsInArray = new System.Collections.ArrayList();

        public void Key()
        {
            // Add key-value pairs as objects containing both key and value

            //Password response
            keyWordsInArray.Add(new KeyValue("Password",
                "Password security is the practice of securing a password from unauthorized access. \n" +
                "You can create a strong password by using a combination of letters, numbers and special characters, and by avoiding common words and phrases. \n" +
                "You can protect your password by keeping it secure and not sharing it with anyone. \n" +
                "If your password is compromised, change it immediately and report it to the relevant authorities."));

            //phishing response
            keyWordsInArray.Add(new KeyValue("Phishing",
                "Phishing is the fraudulent attempt to obtain sensitive information such as usernames, passwords and credit card details. \n" +
                "You can identify phishing by looking out for suspicious emails, websites and requests for sensitive information. \n" +
                "You can protect yourself from phishing by being cautious of suspicious emails and websites, and by not sharing sensitive information online. \n" +
                "If you receive a phishing email, do not click on any links or download attachments. Report it to your email provider and delete it immediately."));

            //password safety response
            keyWordsInArray.Add(new KeyValue("password safety",
                "You can stay safe online by using secure passwords, keeping your software up to date, and being cautious of suspicious emails and websites. \n" +
                "You can protect your personal information online by being cautious of what you share online, and by using privacy settings on social media platforms. \n" +
                "If you encounter a suspicious website, do not enter any personal information. Report it to the relevant authorities and leave the website immediately. \n" +
                "Safety browsing is the practice of ensuring a safe and secure online browsing experience."));
        }

        public void filered_words()
        {
            // Add filtered words to ArrayList
            filteredWords = new System.Collections.ArrayList()
            {
                "tell", "me", "please", "can", "you", "could", "would",
                "how", "what", "when", "where", "why", "who", "which",
                "give", "show", "explain", "describe", "provide", "list",
                "the", "a", "an", "is", "are", "do", "does", "should",
                "will", "might", "may", "must", "have", "has", "had",
                "need", "want", "like", "thanks", "thank", "hello", "hi", "hey"
            };
        }
        //Questions: new Key Value, trim function, 

        public string process_Question(string user_Question)
        {

            List<string> importantWords = new List<string>();

            //1. Split the question into separate words
            //Example: "Can you explain Phishing?" → ["Can", "you", "explain", "Phishing?"]

            string[] questions_asked_by_user = user_Question.Split(' ');

            //2. from splitting the input now it Cleans each word (removes spaces and punctuation) "Phishing?" becomes "Phishing"
            foreach (string word in questions_asked_by_user)
            {
                //trim meaning ignoring any punctuations and whitespaces
                string trimmed_word = word.Trim();

                //3.  Check if the word should be ignored
                //example: if "can" is in filtered words 
                bool isFiltered = false;
                
                foreach (string filteredWord in filteredWords)
                {
                    if (string.Equals(trimmed_word, filteredWord, StringComparison.OrdinalIgnoreCase))
                    {
                        isFiltered = true; //if filtered word matches then mark it as ignored.
                        break; 
                    }
                }
                //4. however if its not there is a word unfiltered then keep the word.
                //example: "Can", "you", "explain", "Phishing?" 
                // three words are filtered above so keep the word "phishing"
                if (!isFiltered)
                {
                    
                    importantWords.Add(trimmed_word); 
                }
            }
            //5. hold the word in this array
            List<string> collects_all_responses = new List<string>();

            // 6. Check if every word matches an important word in our array(database)
            foreach (string word in importantWords)
            {
                //check if the question 
                foreach (KeyValue keyvalue in keyWordsInArray)
                {
                    //making the matched cases insensitive
                    if (string.Equals(word, keyvalue.Key, StringComparison.OrdinalIgnoreCase))
                    {
//if the response does not already contain the key word then add it. if not don't add it so that it does not duplicate
/*
 * Without this check, the same answer could appear twice.
Now: Even if the keyword appears multiple times, the answer is only stored once.*/

if (!collects_all_responses.Contains(keyvalue.Value)) 
{
    collects_all_responses.Add(keyvalue.Value);
         }
      }
   }
}

/*"After checking all words, we look at our list of answers. If the list is not empty then join all answers into a single string.
Separate each answer with two newlines (\n\n) to create a blank line between them.
Return the combined result.*/
if (collects_all_responses.Count > 0)
{
return string.Join("\n\n", collects_all_responses); // ⭐ NEW: Joins all responses
}
// Error handling
Console.ForegroundColor = ConsoleColor.Red;
return " ask something relevant to the topics mentioned above";
}
}

// ArrayList is just a list of objects—it doesn’t have built-in key-value pairing like Dictionary.
//To store and retrieve answers based on keywords, we need a way to link a keyword(e.g., "Phishing") to its answer
//The KeyValue class provides this structure, allowing us to mimic a dictionary.
public class KeyValue
{
// Property to store the keyword (e.g., "Password")
//will be set in the constructor
public string Key { get; }  

// Property to store the full answer text
//will be set in constructor
public string Value { get; } 

// Constructor: Sets the key and value when created
public KeyValue(string key, string value)
{
Key = key;      // Assign keyword
Value = value;  // Assign answer
}

}
}







/*name: .NET Framework CI

on:
push:
branches: [ main ]
pull_request:
branches: [ main ]

jobs:
build:
runs-on: windows-latest

steps:
- name: Checkout repository
uses: actions/checkout@v2

- name: Setup .NET
uses: actions/setup-dotnet@v1
with:
dotnet-version: '4.7.2'
- name: Restore dependencies
run: nuget restore

- name: Build solution
run: msbuild /p:Configuration=Release

- name: Run tests
run: |
vstest.console.exe **\*test*.dll
continue-on-error: true

- name: Check code formatting
run: dotnet format --check
continue-on-error: true

- name: Report build status
if: failure()
run: echo "Build failed"
if: success()
run: echo "Build succeeded"

*/