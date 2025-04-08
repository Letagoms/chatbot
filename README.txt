# Part1
CyberSurfer Chatbot - README
Overview
A console-based cybersecurity assistant that provides interactive guidance on password safety, phishing, and safe browsing with voice greetings, ASCII visuals, and animated text effects.

 Features
1. Voice & Sound 
VoiceGreeting Class

Plays a WAV audio file on startup for a welcoming experience.

Example: "Welcome to CyberSurfer! Your cybersecurity guide."

2. Visual Display 
ImageDisplay Class

Renders ASCII art (e.g., cybersecurity-themed graphics).

Used in the welcome screen and responses.

3. Chat Interface 
chatbegins Class

Color-coded console text (green, blue, magenta, red).

Structured borders and spacing for readability.

Personalized username greeting.

4. Special Effects 
extraEffects Class

Typewriter effect for chatbot responses (TypeWriterEffect()).

Adjustable typing speed (delayPerChar parameter).

5. Smart Responses 🤖
SystemResponse Class

Answers questions about:

Password safety (strong passwords, protection)

Phishing (identification, prevention)

 Safe browsing (privacy, secure habits)

Ignores common words (tell, please, how).

How to Use
Run the program → Hear the voice greeting and see ASCII art.

Enter your name → Chatbot personalizes responses.

Ask questions like:

"How to create a strong password?"

"What is phishing?"

"How to browse safely?"

Type exit to quit.

Customization
Change voice greeting: Replace the .wav file in VoiceGreeting.

Modify ASCII art: Update ImageDisplay with new designs.

Add more responses: Edit SystemResponse.Key().

Requirements
.NET Framework (Windows)

Console app support

Audio playback (for voice)

Example Workflow:
Voice greets you → ASCII logo appears.

You are given what you can ask

your username is asked and used in conversation

You type: "Explain password safety"

Chatbot animates the response in typewriter style:

"Definition: Password safety is..."

Repeat or type exit to end.