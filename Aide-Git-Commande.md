### Rappel avant de push : 

Toujours git pull avant de git add ou git commit !!!!!

Git push dans sa branche et pas besoin de merge on fera des pull request dès qu'un ajout ne possède plus de problème.
#### Pour utiliser repository git en local : 

git clone [Nom du dépôt git];
cd  [Nom du dépôt git];

#### Pour voir toutes les branches créées : 

git branch;

#### Pour créer une nouvelle branche : 

git branch [Nom de la branch];

#### Pour switcher dans la nouvelle branche : 

git checkout [Nom de la nouvelle branche];

#### Pour Vérifier les fichiers modifiés ou trackés par git : 

git status;

#### Pour ajouter les fichiers trackés par git : 

git add -A 
-ou- 
git add --all 
-ou-
git add .

#### Pour faire un commit git  : 

git commit -m "Description du commit";

#### Pour faire un push du repository local en ligne  : 

git push origin [nom de la branche] ";