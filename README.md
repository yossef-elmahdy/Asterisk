# Asterisk
Asterisk is a smart text editor implemented using `C#`, `Windows Forms` and `Microsoft SQL Server`.
It was part of a team project including:
Hady Lotfy - Youssef El-Mahdy - Abdullah El-Hadidy - Saif Gadallah

## Content
- [Overview](#TO-DO)
- [Main Interface Snapshot](#TO-DO)
- [Features](#TO-DO)
- [Used Tools](#TO-DO)


--------------------------------------
## Overview
This project aims to apply what we have learned in C# and Database and make use of our passion
to work on text processing project and know the underneath behind what is happening in common
text processing editors and programs like MS Word, VS Code or Atom.

My role was implementing main features, and testing some of functions and peers
implemented features.

--------------------------------------
## Project Snapshots
![Main Interface](#TO-DO)
<p align="center">
    Asterisk Main Interface
</p>  


--------------------------------------
## Features
Taking Atom as our imagination source, we are trying to implement most of the features
that make it outstanding in addition to main features that we can see in any text editor
such that:
1. Find: Finding a text or a sentence and all of its occurrence in the text.  
2. Find and Replace: Replacing a text or a sentence and all of its occurrence in the text.
3. Font Editing: Ability to edit the font and the text with main formatting options such (bold, italic, size, …).

We are also need to make it smart and have different features like:
1. Themes: You can change the mode of the editor from Light Mode to Dark Mode, and vice versa.
2. Detecting Programming Language: The editor can detect the written language from the extension of the file
while saving it, such that: .cs (C# file), .c (C file), .cpp (C++ file), .java (Java file), …
3. Programming Language Keywords Detection: Detecting the programming language used help the text editor highlight
the keywords of the language with different color, such that: coloring "int" or "double" keyword in C++ or C.
4. English Misspelling Detection: Coloring misspelled English language (using a [dictionary](https://github.com/dwyl/english-words) of nearly all English words) with a red color to identify and correct them.  
5. Autocomplete parentheses and pair symbols: Completing pair symbols while typing them, such that parentheses (),
curly brackets {}, square brackets [], …


---------------------------------------
## Used Tools
1. `C#`:
   - Neary all project source code was implemented using it.
2. `Microsoft Windows Forms`:
   - Make the UI of the project and all tabs and visuals.
3. `Microsoft SQL Server`:
   - Make Database of the programming languages keywords and make integration
   between C# and it.
4. `English Words Flat File`:
   - Text file contains all English language words for English Misspelling Detection feature
