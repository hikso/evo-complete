   M S B A M L   `   `   `  ����A  =EVO_PV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EVO_PV.ViewsEVO_PV.Views  5      %    EVO_PV.Views.UCModalCancelOrder   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:EVO_PV.Views     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5        � 	Resources  5	       �� MergedDictionaries �� Source   Reasons �� Source �� Path �� Mode �� UpdateSourceTrigger�� 5
   
    5      �� 5      $< 6/EVO_PV;Component/Resources/Dictionaries/DictTags.xaml?�6%   �� 5      $2 ,/EVO_PV;Component/Resources/Style/style.xaml?�6%   %W   &	        �� 5       63   �� $ Reasons�$ TwoWay=�$ PropertyChanged=�5      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      � $	��400��6   $	��250��6    � RowDefinitions 5      �� 5      �� 5      �� 5      .+�5      �� $��0��5      $
��Auto��5      $��15q�5      $��Center=�5      $ Vertical=�5       .+�5!      '  !MaterialDesignThemes.Wpf.PackIcon  $	��100��5"      $	��100��5#      $��Center=�5$      
���  ��	   Kind$	 Cancel=�5&      �� 5'      $	��300��5(      $
��15,5q�5)      $��Center=�5*      $��16(�5+      
�������$5��/¿Está seguro que desea cancelar la solicitud?��5-      $
��Wrap=�5.      5/      �� 50      $��1��6   $ Vertical=�6*   .+�51      �� $��0,0,0,20q�52      $��14(�53      $
��Bold"�54      ���#7F0E06$��Motivo de cancelación:��56      
 �� TextAlignment$
 Center=�57      �� 58      -   5         ��Name$ 	cbReasons��59       �� SelectedIndex$ 0��5:       �� SelectedValuePath$ 
ReasonName��5<        ComboBoxStyle#��[ 5=       �� SelectedValue 5;      �� $ 
ReasonName�$ TwoWay=�$ PropertyChanged=���5>      -  'System.Windows.Data.CompositeCollection  5?      �� 5@   "   -   5         ��Name$ 
ReasonName��5A   %   $��Seleccione...��5B   %    �� 
IsSelected$
 True��5C   %   $y�	Collapsed=�5D   %   �� 5E   "    �� 
Collection 66   ��  �� Source# [  5F      ��5H      �� 5I      .R�5J   "   �� .+�5K   &   �� ��60   �� $ 
ReasonName�5L   #   5M      5O      5P      �� 5Q      $��2��5R      $��15q�5S      $��Right=�5T      $��Bottom=�5U      $ 
Horizontal=�5V      .+�5X      �� $��4q�5Y      $��Center=�5Z      
���  ��
���  ��  BtnConfirmationNot#���  5^      ��5]      �� *ConfirmationNotCommand+5^      �� 5`      $��4q�5a      $��Center=�5b      ���#4CAF50���#4CAF50  BtnConfirmationYes#���  5f      ��5e      �� *ConfirmationYesCommand+5f      5g      5h      5i      5j      5k      