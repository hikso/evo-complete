   M S B A M L   `   `   `  ����A  =EVO_PV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EVO_PV.UtilitiesEVO_PV.Utilities  5      $    EVO_PV.Views.UCModalBoxSetting   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      *localclr-namespace:EVO_PV.Utilities  5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      $	��600��5        � 	Resources  5       �� MergedDictionaries �� Source   Requests �� Source �� Path �� Mode �� UpdateSourceTrigger  
Deliveries  Bascules  
WareHouses*   $EVO_PV.Utilities.VisibilityConverter  VisibilityConverter*   $EVO_PV.Utilities.BrushColorConverter  BrushColorConverter  VisibilityConverterBool'   !EVO_PV.Utilities.DecimalConverter  decimalConverter�� 5   
    5      �� 5      $< 6/EVO_PV;Component/Resources/Dictionaries/DictTags.xaml?�6%   �� 5      $2 ,/EVO_PV;Component/Resources/Style/style.xaml?�6%   %�  &	        &	 N     &	 �     &	 �     &	 <    &	 O    &	 b    &	 u    �� 5       64   �� $ Requests�$ TwoWay=�$ PropertyChanged=��� 5       66   �� $ 
Deliveries�$ TwoWay=�$ PropertyChanged=��� 5       64   �� $ Bascules�$ TwoWay=�$ PropertyChanged=��� 5       66   �� $ 
WareHouses�$ TwoWay=�$ PropertyChanged=�  5      6(     5      6(   �� 5      6+     5      6%   5      .��5      � $��	0,10,0,20q�6    � ColumnDefinitions 5    
   �� 5!      $	��60* �6   �� 5"      $	��40* �6   �� 5#      $	��25* �6    � RowDefinitions 5%   
   �� 5&      �� 5'      �� 5(      �� 5)      �� 5*      �� 5+      �� 5,      .+�5.   
   � $	��470��6   .+�5/      �� $��30q�6   .+�50      ��   	TextTitle#��[ 6   $��Apertura Cuadre de Caja��6?   51      52      �� 53   
   $��2��54      $��0��55      $��0,0,0,20q�56       	 
HeaderView#��[	 57      .+�58      ��  
 TextHeaderView#��[
 6     lblIdentificacionCajero#���  6@   �� 59        DataText#��[ 6   ��6:   �� *	User.ID+5:      �� 5<   
   $��2��5=      $��1��5>      $��0,0,0,20q�5?      #��[	 5@      .+�5A      �� #��[
 6     	lblNombre#���  6@   �� 5B      #��[ 6   ��6:   �� *	User.Name+5C      �� 5E   
   $��2��5F      $��2��5G      $��0,0,0,20q�5H      #��[	 5I      .+�5J      �� #��[
 6     lblCargo#���  6@   �� 5K      -   5        	 ��Name$	 PositionsItemControl��5L      
 �� AlternationCount$	
 100��5M      ��5N      �� *User.Positions+$ TwoWay=�$ PropertyChanged=���5O      �� 5P      .R�5Q      A�  A� Columns 6&   �� *User.Positions.Count+$ OneWay=�$ PropertyChanged=�5R      ��5T      �� 5U      .R�5V      �� #��[ 6$   ��6F   �� $ .�$ TwoWay=�$ PropertyChanged=�5W      5Y      5Z      �� 5\   
   $��3��5]      $��0��5^      $��0,0,0,20q�5_      #��[	 5`      .+�5a      �� #��[
 6     lblFechaApertura#���  6@   �� 5b      #��[ 6   ��6:   �� *BoxSettingHeader.OpenDate+5c      �� 5e   
   $��3��5f      $��1��5g      $��0,0,0,20q�5h      #��[	 5i      .+�5j      �� #��[
 6     lblFechaCierre#���  6@   �� 5k      #��[ 6   ��6:   �� *BoxSettingHeader.CloseDate+5l      �� 5n   
   $��4��5o      $��0��5p      $��0,0,0,20q�5q      #��[	 5r      .+�5s      �� #��[
 6     lblValorApertura#���  6@   �� 5t        TextBoxStyle#��[ 5u       �� TextAlignment$ Right=�5w      ��5v      �� *BoxSettingHeader.RealValue+$ TwoWay=�$ PropertyChanged=� �� 	Converter# [  �� ConverterParameter$ Money��.��5w   '   .  (System.Windows.Interactivity.Interaction   Triggers 5x      /  )System.Windows.Interactivity.EventTrigger  5y         	EventName$ KeyUp��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5z      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 6-   �� $ UpdateRealValueCommand�5{        5|      $ 	LostFocus��6%   . 5}         6-   �� $ UpdateRealValueCommand�5~        5      $ TextChanged��6%   . 5�         6-   �� $ UpdateRealValueCommand�5�      .��5�   *   5�      5�      �� 5�   
   $��5��5�      $��0��5�      $��0,0,0,20q�5�      #��[	 5�      .+�5�      �� #��[
 6     lblValorAsignado#���  6@   �� 5�      #��[ 6   ��6:   �� *BoxSettingHeader.AsignedValue+# [ $ Money��5�      �� 5�   
   $��6��5�      $��0��5�      $��0,0,0,20q�5�      #��[	 5�      .+�5�      �� #��[
 6     
lblNovedad#���  6@   �� 5�      #��[ 5�      ��5�      �� $ IsMin�$ TwoWay=�$ PropertyChanged=�# [ ��5�      �� *BoxSettingHeader.Difference+$ TwoWay=�$ PropertyChanged=�# [ $ Money��5�      � 5�   
   $��6��5�      $��0��5�      $��3��5�      .+�5�      �� $	��200��5�      $��	30,30,0,0q�5�      $��Right=�5�      .+�5�      � $��0q�6    5�      �� 5�       5�      �� 5�      �� 5�      .+�5�      �� $��0��6!   $��0��6.   .+�5�      �� -   5         ��Name$ BrowseButton��5�      $
��Auto��5�      $��40��5�      $��0,0,0,0q�5�      $
��Left=�5�      $��Bottom=�5�      
���  �����#00BCD4$��Cancelar��5�      ��5�      �� *CancelCommand+5�      5�      �� 5�      $��0��6!   $��1��6.   .+�5�      �� $
��Auto��5�      $��40��5�      $��0,0,0,0q�5�      $
��Left=�5�      $��Bottom=�5�      ���#4ACF50���#4ACF50$��Aceptar��5�      ��5�      �� *SendBoxSettingCommand+5�      5�      5�      5�      5�      5�      5�      