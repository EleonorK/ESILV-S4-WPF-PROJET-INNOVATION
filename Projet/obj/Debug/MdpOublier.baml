   M S B A M L   `   `   `  ????A  =Projet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ProjetProjet  5   	       Projet.MdpOublier   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Projet     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#???   5	      $??Regular"?5
      $??13(?5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5         TextRenderingMode$
 Auto=?5        MaterialDesignPaper#???  5        MaterialDesignFont#???  5       ? Title$ 
MdpOublier??5   	   $	??500??6   $	??400??6)    ? AllowsTransparency .  ? WindowStyle$
 None=?6O   .??5      ? .+?5   
   ??  . *MaterialDesignFloatingActionMiniDarkButton#??[ 5       ? ToolTip$ Vérification en cours...??5      $??337,64,10,383q?6&   $
??Auto??6=   $
??Auto??6K   .??5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountQuestionOutline=?5      $??22??6#   $??25??6/   5      ?? 5   
   $+??%Nous devons vérifier votre identité??6   $
??Left=?6>   $??3,79,0,0q?6Y   $	??Top=?6k   $
??Bold"?6?   $??19(?6?   $	??329??6?   $??38??6?   ?? 5   
   $K??ERépondez aux questions de sécurité pour accéder 
à votre compte ??6   $
??Left=?6_   $??
28,132,0,0q?6z   $	??Top=?6?   $??13(?6?   $??Italic$?6?   $??46??6?   $	??292??6?   ?? 5   
   $K??EVous disposez de 5 essais maximum 
sinon votre compte sera supprimé??6   $
??Left=?6g   $??182,415,0,0q?6?   $	??Top=?6?   $??13(?6?   $??Italic$?6?   ???	#DDFF0707??6?   Z? 6?   ?? 5   
   -   5         ??Name$	 nom??5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Nom d'utilisateur??5      
   
HelperText$
  ??5      $??28,205,80,257q?6+   .??6B   ??5       ?? 5!       ?? Path$
 Name?5"       ?? UpdateSourceTrigger$ PropertyChanged=?5#      5$      .??5%      5&      ?? 5'   
   -   5        $ 	question1??5(       . $4	 .Quel est le lieu de naissance de votre père ???5*      $
  ??5+      $??28,273,28,192q?6+    J? RenderTransformOrigin$ 
0.508,0.82&?6B   .??6e   ??5,      ?? 5-      $
 Name?5.      $ PropertyChanged=?5/      50      .??51      52      ?? 53   
   -   5        $ 	question2??54       . $)	 #Quelle est votre couleur favorite ???56      $
  ??57      $??28,338,48,121q?6+   .??6B   ??58      ?? 59      $
 Name?5:      $ PropertyChanged=?5;      5<      .??5=      5>      ?? 5?   
   -   5         " MaterialDesignRaisedDarkButton#??[ 5@      $ Valider??5A      $??OK??5B      $??28,414,242,46q?6!   $
??Auto??68   ?? 5C   
   -   5        #??[ 5D      $ Page précédente??5E      $??10,10,346,449q?6   $
??Auto??64   $
??Auto??6B   ???	#DD000000???	#FFDADADA??6d   Z? .??5F        $ 	ArrowBack=?5G      $??26??6   $??28??6"   5H      5I      5J      