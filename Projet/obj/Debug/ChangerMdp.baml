   M S B A M L   `   `   `  ????A  =Projet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ProjetProjet  5   	       Projet.ChangerMdp   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Projet     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#???   5	      $??Regular"?5
      $??13(?5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5         TextRenderingMode$
 Auto=?5        MaterialDesignPaper#???  5        MaterialDesignFont#???  5       ? Title$ 
ChangerMdp??5   	   $	??500??6   $	??400??6)    ? AllowsTransparency .  ? WindowStyle$
 None=?6O   .??5      ? .+?5   
   ?? $??Changer mon mot de passe??6   $
??Left=?63   $??	59,59,0,0q?6N   $	??Top=?6a   $	??274??6y   $??20(?6?   $
??Bold"?6?   ?? 5   
   -   5         ??Name$	 nom??5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nom d'utilisateur??5      $??40,129,56,313q?5      .??6   ??5      ?? 5       ?? Path$
 Name?5      	 ?? UpdateSourceTrigger$	 PropertyChanged=?5      5      .??5      5      G? 5   
   -   5        
 G?Name$
 oldPassword??5        . $ Ancien mot de passe??5"         
Foreground
 ? ? ?   UnderlineBrush
 ? ? ? ) %MaterialDesignFloatingHintPasswordBox#??[ 5%      $??40,220,56,222q?6B   G? 5&   
   -   5        $
 newPassword??5'      $ Nouveau mot de passe??5(      
 ? ? ?
 ? ? ?#??[ 5+      $??40,316,56,126q?6B    . 6Y   ?? 5,   
   -   5         " MaterialDesignRaisedDarkButton#??[ 5-       ? ToolTip$ Valider??5.      $??OK??5/      $??124,410,126,58q?6   6(   ?? 50   
   -   5         . *MaterialDesignFloatingActionMiniDarkButton#??[ 51      $ Page précédente??52      $??10,10,350,450q?6   
??????????	#FFF6E1E1???	#DD000000.??53      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=?54      $??30??6   $??22??6"   55      ?? 56   
   -   5        #??[ 57      $ Déconnexion??58      $??350,10,10,450q?6#   
??????????	#FFF6E1E1???	#DD000000 J? RenderTransformOrigin$ 
0.715,0.91&?6?   .??59        $ 
AccountOff=?5:      $??30??6#   $??22??6/   5;      5=      5>      