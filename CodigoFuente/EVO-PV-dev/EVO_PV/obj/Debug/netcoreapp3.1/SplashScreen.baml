   M S B A M L   `   `   `  ����A  =EVO_PV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:EVO_PV.ViewModelsEVO_PV.ViewModels  5   	       EVO_PV.SplashScreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:EVO_PV.ViewModels     5   	     � Title$   ��5   	   $	��420��5	   	   $	��650��5
   	    � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � DataContext 5      &    EVO_PV.ViewModels.VMSplashScreen  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��0��5      $��3��5       $��0��5!      $#��/Resources/Images/LogoEvo.png��5"      5$      �� 5%   
   $��3��5&      $��0��5'       �� Orientation$ 
Horizontal=�5(      $��Right=�5)      $	��Top=�5*      .+�5,      �� -   5        	 ��Name$	 
lblVersion��5-      ���#FFFFFF$
��Bold"�50      $��16(�51      $��	0,0,120,0q�52      ��5/      �� *	Version+54      55      �� 56   
   $��3��57      $��0��58      $ 
Horizontal=�59      $��Center=�5:      $��Center=�5;      .+�5=      �� $��Cargando...��5>      $
��Bold"�5?      $��30(�5@      ���#F5B90E5C      5D      5E      5G      