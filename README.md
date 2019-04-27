# LD44
Ludum Dare 44


TODO : Create Unity project with necessary version control

- Edit->Project Settings->Editor in the application menu and enabling External Version Control support by selecting Visible Meta Files in the dropdown for Version Control
- you should add the Assets, Packages and the ProjectSettings directories

Git
Add the following text to your .git or .gitconfig file:

[merge]
    tool = unityyamlmerge

[mergetool "unityyamlmerge"]
    trustExitCode = false
    cmd = 'C:\\Program Files\\Unity\\Hub\\Editor\\2019.1.0f2\\Editor\\Data\\Tools\\UnityYAMLMerge.exe' merge -p \"$BASE\" \"$REMOTE\" \"$LOCAL\" \"$MERGED\"

C:\Program Files\Unity\Hub\Editor\2019.1.0f2\Editor\Data\Tools\UnityYAMLMerge.exe
or
C:\Program Files (x86)\Unity\Editor\Data\Tools\UnityYAMLMerge.exe
