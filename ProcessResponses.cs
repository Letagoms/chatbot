using System;
using System.Collections.Generic;
using System.Linq;

namespace Part1
{
    public class ProcessResponses
    {
        private readonly List<string> _memoryRecallTriggers = new List<string>
{
    "protect", "secure", "safeguard", "defend", "avoid", "prevent", "stop",
    "help", "advice", "tips", "tricks", "guide", "steps", "actions",
    "what to do", "what now", "next steps", "not sure", "confused", "lost",
    "remember", "recall", "you mentioned", "before", "earlier", "previous"
};
// Stores conversation history
        private UserMemory _memory = new UserMemory(); 

        public class UserMemory
        {
            public List<string> Interests { get; } = new List<string>();

            public void AddInterest(string interest)
            {
                if (!Interests.Contains(interest.ToLower()))
                    Interests.Add(interest.ToLower());
            }
        }


        public string GetResponse(string userInput)
        {
            var store = new StoreResponses();
            store.filtered_words();
            store.sentiment_words();
            store.Key();
            store.negative();
            var random = new Random();

            //1. lower the input
            string lowerInput = userInput.ToLower();

            //2. If the user has interests stored and either the input contains a recall them
            if (_memory.Interests.Count > 0 &&
                 (_memoryRecallTriggers.Any(trigger => lowerInput.Contains(trigger)) || random.Next(5) == 0))
            {
                //3. Pick a random interest from the user's stored interests
                string randomInterest = _memory.Interests[random.Next(_memory.Interests.Count)];
                //4. Find a matching keyword response for that interest
                var matchingResponse = store.KeyWords.FirstOrDefault(k => k.Key.Equals(randomInterest, StringComparison.OrdinalIgnoreCase));
                if (matchingResponse != null)
                {
                    //5. Get a random sentence from the matching response
                    var tip = GetRandomSentence(matchingResponse.Value, random);
                    //6. Return a memory recall message with the tip
                    return $"As someone interested in {randomInterest}, remember: {tip}";
                }
            }

            // 2. INTEREST DETECTION: Check if user declares an interest
            if (lowerInput.Contains("interested in") || lowerInput.Contains("care about"))
            {
                foreach (var kv in store.KeyWords)
                {
                    if (lowerInput.Contains(kv.Key.ToLower()))
                    {
                        _memory.AddInterest(kv.Key);
                        return $"I'll remember you're interested in {kv.Key}. {GetRandomSentence(kv.Value, random)}";
                    }
                }
            }


            //1. split unfiltered words, lower their cases, trim and convert to list
            var unfiltered_words = userInput.Split()
                .Select(w => w.ToLower().Trim())
                .Where(w => !store.FilteredWords.Contains(w))
                .ToList();
   
            foreach (var word in unfiltered_words)
            {
                //2. look for stored keywords in inside the unfiltered word. if its not equal not nothing proceed.
                var kv = store.KeyWords.FirstOrDefault(k => word.Contains(k.Key.ToLower()));
                if (kv != null)
                {
                    //renaming the negative stored sentiment and lowering the cases
                 bool isNegative = store.NegativeWords.Any(neg => lowerInput.Contains(neg));

              
             string Response = isNegative
            // 3. If true (meaning response is negative), look for a matching stored sentiment feedback in SentimentMethods If a match is found, get its sentiment_response; if not, this is null
             ? store.SentimentFeedback
            .FirstOrDefault(nr => nr.sentiment_word.Equals(kv.Key, StringComparison.OrdinalIgnoreCase))
            ?.sentiment_response

             //4. If no sentiment response is found (null), use the default keyword response (kv.Value)
            ?? kv.Value
            // If isNegative is false, just use the default keyword response (kv.Value)
            : kv.Value;

             //5. take the response and split, trim and convert to List
             var sentences = Response.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(s => s.Trim())
                                      .Where(s => !string.IsNullOrWhiteSpace(s))
                                      .ToList();

                    //6. if theres more than one sentence, return a random response
                    if (sentences.Count > 1)
                    {
                        return sentences[random.Next(sentences.Count)] + ".";
                    }
                    return Response;
                }
            }

            return "I'm not sure how to help with that. Try asking about password safety, phishing, or safe browsing.";
        }

        private string GetRandomSentence(string text, Random random)
        {
            var sentences = text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(s => s.Trim())
                           .Where(s => !string.IsNullOrWhiteSpace(s))
                           .ToList();
            return sentences.Count > 0 ? sentences[random.Next(sentences.Count)] + "." : text;
        }
    }
}
