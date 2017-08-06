Create NEO Smart Contract in Visual Studio 2017

1. Open Visual Studion.


2. In Team explorer Click Clone and insert the neo-compiler link: https://github.com/neo-project/neo-compiler

![GitHub Logo](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAA1KAAAAJDRiYjgzYmM4LWIzMzEtNDExZS04MWU5LTdhY2NkNjQ2MGU5Nw.png)

3. Create the Git repo by clicking Clone



4. Double click on neo-compiler.sln


![GitHub Logo2](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAArOAAAAJGQzMDQ2MzRhLWUwYzYtNDIyNS1iNTYyLWYwNjI5MTQxZDlhZQ.png)

 
5. Click Solution explorer:


![GitHub Logo3](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAvpAAAAJDRlNDI4MjczLWIwYmItNDNmNy04NDY4LTBjYzM1ODcxN2YyZA.png)


 
6. Right click on ’neon’ and select Publish

![GitHub Logo4](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAv3AAAAJGU3M2I4ZmExLTI0YmYtNDRjYS05NDBkLTIzYmIwZWQzZGRlYw.png)

 
7. Click on Publish.

8. Check your Output window:

![GitHub Logo5](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAxeAAAAJDQ2ZWE2NmEzLTNlOTYtNDQwMi1hNjA3LTJmY2Y4NDI3ZTU4NA.png)

  
9. Navigate to your directory (Target Location), where you can find neon.exe:

![GitHub Logo6](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAx4AAAAJGI3YWZmMzMzLTI3MzEtNGM3Zi04NDM1LWFiNWQxZmQyYTVlNA.png)

10. You have to add this directory path to the PATH environment variable:

![GitHub Logo7](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAArvAAAAJGZkMDQzY2M1LTIzZDUtNDhlZi05M2FmLWI5NDMyMmU4ZmM2Mg.png)

11. We can check how it works. Run cmd and type ’neon’:


![GitHub Logo8](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAt_AAAAJDA4YmJkZjlkLWJhOGUtNDUzZS05Y2M0LWE0Y2ExN2E4YmYzZA.png)

12. Now create a new project in Visual Studio 2017:

	File->New->Project
    
![GitHub Logo9](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAzsAAAAJGVjMDY3ZmYwLTcwYjYtNGJlMi04ZTNmLTlkZTY4OTgxOTQ3Yg.png)

Select Console App (.NET Core) and type ’HelloProject’ in the Name field. Then click OK.

13. Right click on Dependencies:

![GitHub Logo10](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAriAAAAJDlmYWEzZjgzLTU5MmQtNDA1MS1iZWUwLTI5Mjg1YTVlYzE1Mg.png)
 
14. Add reference. Click Browse, and select neon.dll


![GitHub Logo11](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAA0rAAAAJDUwY2Y3ODkzLWNmMWQtNGU2NS05MDY2LTViNjkzMGM3OWI2MA.png)

Add it. Then OK.

15. Navigate to NuGet package manager:

![GitHub Logo12](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAteAAAAJGM2OGFiM2VkLTU3YWItNDljZS1iOTVhLTY5YWNhNTdlMzEyNw.png)


16. Click Browse and select Neo.SmartContract.Framework. Then click Install.
 
![GitHub Logo13](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAwTAAAAJGJhNmM2MTdlLWZiMjgtNDU3NC1iMTVmLWQwYTFhYjM5ZGYyYQ.png)


17. Now we can insert our Hello world code:

![GitHub Logo14](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAArsAAAAJDU1ZGEyZjg2LThlMDItNGNhOC1iMGEzLWMyMzVlYzgyYzNlNQ.png)

 
18. Build the project:


 
![GitHub Logo15](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAqQAAAAJGE2NTUxYmFjLTMxNjItNGJkMC05Nzk4LWUwODJhOTVlNDA2NA.png)

 
19. Publish:
 
![GitHub Logo16](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAA3eAAAAJGYxODY2NzdiLWJkN2ItNDlmNy1iZGQ4LTI3ZTc1YTY3MTBlYg.png)

20.  Navigate to the directory whick contains .dll file:

![GitHub Logo17](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAqYAAAAJDMwNDAzMjNmLTc3MTMtNDY3Mi05NGEyLThjY2MwNWQyZDJkMA.png)

21. Compile it, type: neon HelloProject.dll

![GitHub Logo18](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAAwhAAAAJGVjMGQwMzg2LTBjYTYtNDg3OS1hODNmLTk2YTYyMTA0ZGU0Ng.png)

![GitHub Logo19](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAA0lAAAAJDg0YzYwZGQ3LTg2M2EtNDE2MC1hMzE5LTZlNTEzYWRiM2Q1NA.png)
 

  
Now we get the .avm file:
![GitHub Logo20](https://media.licdn.com/mpr/mpr/AAEAAQAAAAAAAArIAAAAJDZjODFmNTdjLWIzZGMtNGI0Ni1hN2UxLTY4NzhlZjA0YjA3ZQ.png)



