   M S B A M L   `   `   `  ����A  =EVO_PV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EVO_PV.UtilitiesEVO_PV.Utilities  5      &     EVO_PV.Views.UCModalClientFilter   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      *localclr-namespace:EVO_PV.Utilities  5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      $	��500��5        � 	Resources  5       �� MergedDictionaries �� Source   Requests �� Source �� Path �� Mode �� UpdateSourceTrigger  
Deliveries  Bascules  
WareHouses*   $EVO_PV.Utilities.VisibilityConverter  VisibilityConverter*   $EVO_PV.Utilities.BrushColorConverter  BrushColorConverter  VisibilityConverterBool'   !EVO_PV.Utilities.DecimalConverter  decimalConverter�� 5   
    5      �� 5      $< 6/EVO_PV;Component/Resources/Dictionaries/DictTags.xaml?�6%   �� 5      $2 ,/EVO_PV;Component/Resources/Style/style.xaml?�6%   %�  &	        &	 N     &	 �     &	 �     &	 <    &	 O    &	 b    &	 u    �� 5       64   �� $ Requests�$ TwoWay=�$ PropertyChanged=��� 5       66   �� $ 
Deliveries�$ TwoWay=�$ PropertyChanged=��� 5       64   �� $ Bascules�$ TwoWay=�$ PropertyChanged=��� 5       66   �� $ 
WareHouses�$ TwoWay=�$ PropertyChanged=�  5      6(     5      6(   �� 5      6+     5      6%   5      .��5      � $��	0,10,0,20q�6    � ColumnDefinitions 5    
   �� 5!      $��* �6    � RowDefinitions 5#   
   �� 5$      �� 5%      $	��300 �6   �� 5&      .+�5(   
   � $
��Auto��6   .+�5)      �� $��30q�6   .+�5*      ��   	TextTitle#��[ 6   $��Consulta de clientes��6?   5+      5,      �� 5-   
   $��1��5.      $��0��5/      $��0,0,0,20q�50      .+�51      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dgDeliveryArticles��52      $��0��53      $��2��54      $��0��55      $��5��56      $
��Auto��57      $	��300��58      $��Center=�59      $��Center=�5:      
   AutoGenerateColumns$
 False��5;         CanUserAddRows$ False��5<         CanUserDeleteRows$ False��5=         CanUserReorderColumns$ False��5>         CanUserResizeColumns$
 True��5?      $
��True��5A      $
��Auto=�5B      $
��Auto=�5C         SelectionMode$ Single=�5E         SelectionUnit$ FullRow=�5F       	 DataGridStyle#��[	 5G      "   VerticalScrollBarVisibility$
 Auto=�5H      ��5@      �� *ExternalClients+ �� SelectedItem 5D      �� *
Customer+  5J      �� 5K      %   &	         5L      61   5M      ��5O      �� 5P       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5Q      ��  �� Property � �� �� Value 67   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=�5R         Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 5* 5V         Header$ Identificación Cliente��5X         
IsReadOnly$
 True��5Y      1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5W      �� $ Identification�   HeaderTemplate 5Z      �� 5[      .R�5\   "   ��  �� Orientation$ Vertical=�6-   .+�5]   &   �� $
��Bold"�5^   )   ���#7F0E06$
��Wrap=�5a   )   ��5`   )   �� *	Content+ �� RelativeSource ��  �� Mode$ TemplatedParent=�5a   )   �� 5b   &   ��6.   �� $&  DataContext.FilterIdentification�$ TwoWay=�$ PropertyChanged=� �� *FindAncestor+ �� AncestorType"  .��6�   .
  (System.Windows.Interactivity.Interaction  
  Triggers  5c   *   /  )System.Windows.Interactivity.EventTrigger  5d   .   !   	EventName$! KeyDown��6=   .  (System.Windows.Interactivity.TriggerBase"   Actions." 5e   2   /  )GalaSoft.MvvmLight.Command.EventToCommand  #   Command# 6E   �� $/ )DataContext.FilterDeliveryArticlesCommand� �� *FindAncestor+"  5f   /   .��5g   B   5h   '   5i   #   5j      5l        5n      $ 5* 5o      $ Nombre��5q      $
 True��5r       5p      �� $
 Name� 5t      �� 5u      .R�5v   "   �� $ Vertical=�6-   .+�5w   &   �� $
��Bold"�5x   )   ���#7F0E06$
��Wrap=�5{   )   ��5z   )   �� *	Content+ �� $ TemplatedParent=�5{   )   �� 5|   &   $	��200��6.   ��6=   �� $ DataContext.FilterName�$ TwoWay=�$ PropertyChanged=� �� *FindAncestor+"  .��6�     5}   *     5~   .   $! KeyDown��6=   ." 5   2     # 6E   �� $/ )DataContext.FilterDeliveryArticlesCommand� �� *FindAncestor+"  5�   /   .��5�   B   5�   '   5�   #   5�      5�      5�      5�      �� 5�   
   $��2��6   $	��300��6"   .+�5�      �� $��0��5�      $��0��5�      $��	0,0,0,-50q�5�      $
��Left=�5�      .+�5�      �� -   5        $ ��Name$$ BrowseButton��5�      $
��Auto��5�      $��40��5�      $��0,0,0,0q�5�      $
��Left=�5�      $��Bottom=�5�      
���  �����#00BCD4$��Cancelar��5�      ��5�      �� *CancelCommand+5�      5�      �� 5�      $��0��5�      $��0��5�      $��Right=�5�      .+�5�      �� $
��Auto��5�      $��40��5�      $��0,0,0,0q�5�      $
��Left=�5�      $��Bottom=�5�      ���#4ACF50���#4ACF50$��Aceptar��5�      ��5�      �� *SendUserCommand+5�      5�      5�      5�      5�      