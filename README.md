# Cracking A Simple Windows App

The purpose of this program is to crack a basic windows app so that the registration key is no longer required.
The program was written in C#. Some of the code is reworked code from the original windows app. DotPeek was used to discover the original code.

1. Run the 'ConsoleApplication.exe' file without Licence.xml and Public.xml in the folder
2. The app should write both these files
3. You may then open w3Client.exe without any registration key

- Please see ->NewConsole->ConsoleApplication1-> 'signaturexmlwrapper.cs, Program.cs and compinfo.cs to see how the crack was done.
- Another crack was also achieved by decompiling the assembly code and removing the check for the registration. Unfortunately I cannot seem to find this crack anymore.

Please note that I did not design the original windows app, nor its security. I was only responsible for the .cs documents mentioned above.
