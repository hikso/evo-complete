   M S B A M L   `   `   `  ����L  HNotifications.Wpf, Version=0.1.1.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Notifications.Wpf.Controls;assembly=Notifications.WpfNotifications.Wpf.Controls  5      U QSystem.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 5	      
 EVO_PV   EVO_PV.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      XcontrolsCclr-namespace:Notifications.Wpf.Controls;assembly=Notifications.Wpf     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      9system,clr-namespace:System;assembly=System.Runtime  5	        �Language$  ES-mx�5       � Title$ Evo Punto de Venta��5
      $	��800��5      $	��450��5       � WindowStartupLocation$ CenterScreen=�5       � WindowState$ 	Maximized=�5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $2 ,/EVO_PV;Component/Resources/Style/style.xaml?�6%   %    5       � Triggers 5      :� 5   
    :� RoutedEvent$ ButtonBase.Click��6   	 :� 
SourceName$	 ButtonOpenMenu��66   .[�5      ��    MenuOpen#��[  6   5      :� 5   
   $ ButtonBase.Click��6   $	 ButtonCloseMenu��66   .[�5       ��   	MenuClose#��[ 6   5!      .��5%      � -   5        
 �Name$
 principalGrid��5%       � RowDefinitions 5&   
   �� 5'      $��* �6    � ColumnDefinitions 5)   
   �� 5*      -   5         ��Name$ ColumnGridMenu��5*      $
��Auto �67   �� 5+      $��* �6   .+�50   
   1   +Notifications.Wpf.Controls.NotificationArea  -   5          Name$ 
WindowArea��51      $��2��52      $��0,0,30,0q�53      $��Right=�54      $	��Top=�55      $��Stretch=�56      $��Stretch=�57       K� ZIndex$ 99999999��58       � IsSharedSizeScope$
 True��59         MaxItems$ 10��5:         Position$ TopRight=�5;      � 5<   
   -   5        $
 GridMenu��5=      $��1��5>      $��0��5?        GridMenu#��[ 5@      ��5A      �� 5B       �� ImageSource$# /Resources/Images/Sidebar.jpg��6    �� Opacity$	 0.1Q�6I   .+�5D      �  5E      �� 5F      $	��100 �6$   �� 5G      $��2 �6$   �� 5H      $
��326* �6$    5J      �� 5K      .+�5M      �� $��0��6     ContentLogo#��[ 6*   .+�5N      � -   5        $
 
contentImg��5N      $	��100��6/   .+�5P      �� -   5         ��Name$ 	ImageOpen��5Q        LogoEvoOpen#��[ 5S      ��5R      Z� ��5T      �� 5U   "   $# /Resources/Images/LogoEvo.png��6-    j� Stretch$ Uniform=�6Y   5W      �� 5Y      -   5        $ 
ImageClose��5Z        LogoEvoClose#��[ 5\      ��5[      Z� ��5]      �� 5^   "   $# /Resources/Images/LogoEvo.png��6-   $ Uniform=�6Y   5`      5b      5c      �� 5e      $��1��6     Line#��[ 6)   �� 5g      -   5         ��Name$ 
ScrollMenu��5h      $��2��5i        
ScrollMenu#���  5j      .��5k      �� -	   5         ��Name$
 Menu��5k   !   $��
10,10,10,0q�6/   5l      5m      5n      � 5p   
   -
   5        $
 GridContent��5q      $��1��5r        ContentPage#��[ 5s       5u      �� 5v      $��* �6#    5y      �� 5z      $��10 �6    �� 5{      $��* �6    .+�5~      �� $ 1��6   .+�5      �� -   5        $ ButtonOpenMenu��5�      $��0��5�      $��40��5�      $��40��5�      $��20,15q�5�      $��0q�5�      $
��Left=�5�      $	��Top=�5�      ���#ffffff���#ffffff 0	 ,MaterialDesignFloatingActionMiniAccentButton#��[	 5�      $y�	Collapsed=�5�      .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  ���#999999   Kind$ 	ViewQuilt=�6C   5�      �� 5�      -   5        $ ButtonCloseMenu��5�      $��0��5�      $��40��5�      $��40��5�      $��20,15q�5�      $��0q�5�      $
��Left=�5�      $	��Top=�5�      ���#ffffff���#ffffff#��[	 5�      .��5�        ���#999999$ MoreVert=�6C   5�      5�      �� 5�      $��0��5�      $��Stretch=�5�      $��Stretch=�5�      .��5�       � -   5          �Name$ StickyContent��5�       
 PrincipalFrame#��[
 6/   5�      �� 5�      -   5        $ GeneralScroll��5�      $��1��5�        GeneralScroll#��[ 5�      .��5�      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$  TransitioningContentSlides��5�      $��1��5�      $��0,0,0,0q�5�      C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 5�      D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromRight+   Duration 0:0:0.5.��5�       � -   5        $ ContentPage��5�      #��[
 61   5�      5�      5�      )  #MaterialDesignThemes.Wpf.DialogHost  5�   
   -   5          Name$ ModalPrincipal��5�      $��2��5�         CloseOnClickAway$
 True��5�          IsOpen  5�      �� *IsOpenModal+!   DialogContent! 5�       � 5�      -   5        $ ModalContainer��5�      #��[
 60   5�        5�   
   -   5        $  ModalPrincipalConfirmation��5�      $��2��5�      $
 True��5�        5�      �� *IsOpenModal+! 5�       � 5�      -   5        $  ModalContainerConfirmation��5�      #��[
 6<   5�        5�   
   -   5        $ ModalLoading��5�      $��2��5�      
������ $
 True��5�      $
  True��5�      ! 5�       � 5�      -   5        $ LoadingElement��5�      $	��400��5�      $	��200��5�      
������ #��[
 5�      5�      �� 5�   
   -   5        " ��Name$" InformationLayer��5�      $��1��5�      $	��800��5�      $��30��5�      $��	30,0,0,60q�5�      $
��Left=�5�      $��Bottom=�5�      .+�5�       � -   5        $ FrameUCPopPages��5�      5�      5�      5�      