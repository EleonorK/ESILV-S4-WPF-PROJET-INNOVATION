   M S B A M L   `   `   `  ????A  =Projet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ProjetProjet  5   	       Projet.Parametre   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Projet     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#???   5	      $??Regular"?5
      $??13(?5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5         TextRenderingMode$
 Auto=?5        MaterialDesignPaper#???  5        MaterialDesignFont#???  5       ? Title$ 	Parametre??5   	   $	??500??6   $	??400??6(   $y?Visible=?64    ? AllowsTransparency .  ? WindowStyle$
 None=?6c   .??5      ? .+?5   
   ?? $#??Changer mon nom d'utilisateur??6   $
??Left=?68   $??
62,100,0,0q?6S   $	??Top=?6g   $??20(?6   $
??Bold"?6?   ?? 5   
   -   5         ??Name$ oldName??5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Ancien nom??5         
HelperText$  ??5      $??62,158,56,285q?6+   .??6B   ??5      ?? 5      	 ?? Path$
	 Name?5      
 ?? UpdateSourceTrigger$
 PropertyChanged=?5      5      .??5      5      ?? 5    
   -   5        $ newName??5!       . $ Nouveau nom??5#      $  ??5$      $??62,253,56,196q?6+   .??6B   ??5%      ?? 5&      $
	 Name?5'      $
 PropertyChanged=?5(      5)      .??5*      5+      ?? 5,   
   -   5         " MaterialDesignFlatDarkBgButton#??[ 5-       ? ToolTip$ Valider??5.      $??OK??5/      $??132,351,140,113q?6   $
??Auto??6B   ? 50   
   .+?51      ?? -   5         " MaterialDesignRaisedDarkButton#??[ 52      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25??53      $% Réinitialiser mon mot de passe??54      $??80,415,81,43q?6.   ???	#DD930E0E???	#FFA2D9F1$
??Auto??6?   ??6D   Z? .??55      ?? $??Changer mon mot de passe??56      ???	#DD0096FF6'   57      ?? 58      -   5         . *MaterialDesignFloatingActionMiniDarkButton#??[ 59      $ Page précédente??5:      $??20,30,336,424q?6+   
??????????	#FFF6E1E1???	#DD000000$
??Auto??6?   $
??Auto??6?   .??5;      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=?5<      $??30??6&   $??22??62   5=      ?? 5>      -   5        #??[ 5?      $ Déconnexion??5@      $??331,30,25,424q?6'   
??????????	#FFF6E1E1???	#DD000000$
??Auto??6?   $
??Auto??6?    J? RenderTransformOrigin$ 
0.188,0.54&?6?   .??5A        $ 
AccountOff=?5B      $??30??6'   $??22??63   5C      5D      5E      5F      