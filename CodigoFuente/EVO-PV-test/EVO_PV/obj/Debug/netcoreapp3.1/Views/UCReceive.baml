   M S B A M L   `   `   `  ����A  =EVO_PV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EVO_PV.UtilitiesEVO_PV.Utilities  5          EVO_PV.Views.UCReceive   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      *localclr-namespace:EVO_PV.Utilities  5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      $
��1024��5      $
��Auto��5        � 	Resources  5       �� MergedDictionaries �� Source   Requests �� Source �� Path �� Mode �� UpdateSourceTrigger  
Deliveries  Bascules  
WareHouses*   $EVO_PV.Utilities.VisibilityConverter  VisibilityConverter  VisibilityConverterBool1   +EVO_PV.Utilities.BrushColorBasculeConverter  BrushColorBasculeConverter'   !EVO_PV.Utilities.DecimalConverter  decimalConverter�� 5   
    5      �� 5      $< 6/EVO_PV;Component/Resources/Dictionaries/DictTags.xaml?�6%   �� 5      $2 ,/EVO_PV;Component/Resources/Style/style.xaml?�6%   %�  &	        &	 N     &	 �     &	 �     &	 <    &	 O    &	 b    &	 u    �� 5       64   �� $ Requests�$ TwoWay=�$ PropertyChanged=��� 5       66   �� $ 
Deliveries�$ TwoWay=�$ PropertyChanged=��� 5       64   �� $ Bascules�$ TwoWay=�$ PropertyChanged=��� 5       66   �� $ 
WareHouses�$ TwoWay=�$ PropertyChanged=�  5      6(   �� 5      6+     5      6/     5      6%   5      .��5      � ���#eee � ColumnDefinitions 5!   
   �� 5"      $��* �6    � RowDefinitions 5%   
   �� 5&      .+�5)   
   � $��0��6   $��0,40,0,0q�6   .+�5*      #  MaterialDesignThemes.Wpf.Card  $��1��6"   $��
30,0,30,10q�6/   .��5+      �   ContentCard#��[ 6   .+�5,      �� .+�5-      �� .+�5.      � $��0,0,0,0q�6#    5/   "   �� 50   &   $	��25* �67   �� 51   &   $	��25* �67   �� 52   &   $	��25* �67   �� 53   &   $	��25* �67    55   "   �� 56   &   .+�58   "   �� $��0��59   %   $��4��5:   %   $��Right=�5;   %   	 �� Orientation$	 
Horizontal=�5<   %    	 
HeaderView#��[	 5=   %   y�5>   %   �� $ 
DeliveryId�
 �� 	Converter#
 [ .+�5?   &   �� -   5         ��Name$ btnOpenEvidence��5@   )   $��0,0,5,0q�5A   )   ���#4ACF50���#4ACF50$��Enviar Inconsistencias��5E   )   ��5D   )   �� *OpenEvidenceFormCommand+5E   )   5F   #   5G      � 5H      $��	0,10,0,20q�6#    5I   "   �� 5J   &   $	��25* �67   �� 5K   &   $	��25* �67   �� 5L   &   $	��25* �67   �� 5M   &   $	��25* �67    5O   "   �� 5P   &   �� 5Q   &   �� 5R   &   �� 5S   &   .+�5V   "   �� $��1��5W   %   $��0��5X   %   $��0,0,0,30q�5Y   %   $	 
Horizontal=�5Z   %   #��[	 5[   %   .+�5\   &   ��  
 TextHeaderView#��[
 60     lblConsecutive#���  6X   �� 5]   &     DataText#��[ 60   ��6R   �� *DeliveryHeader.Consecutive+5^   #   �� 5`   "   $��1��5a   %   $��1��5b   %   #��[	 5c   %   .+�5d   &   �� #��[
 60     lblFechaEntrega#���  6X   �� 5e   &   #��[ 60   ��6R   �� *DeliveryHeader.DeliveryDate+5f   #   �� 5h   "   $��2��5i   %   $��0��5j   %   $	 
Horizontal=�5k   %   #��[	 5l   %   .+�5m   &   �� #��[
 60     	lblPedido#���  6X   �� 5n   &    �� SelectedIndex$ 0��5o   )    �� SelectedValuePath$ OrderId��5q   )     ComboBoxStyle#��[ 5r   )    �� SelectedValue 5p   )   �� $ OrderId�$ TwoWay=�$ PropertyChanged=���5s   *   -  'System.Windows.Data.CompositeCollection  5t   .   �� 5u   2   -   5         ��Name$ Codigo��5v   5   $��Seleccione...��5w   5    �� 
IsSelected$
 True��5x   5   $y�	Collapsed=�5y   5   �� 5z   2    �� 
Collection 6F   ��  �� Source# [  5{   /   ��5}   *   �� 5~   .   .R�5   2   �� .+�5�   6   �� ��6@   �� $
 Code�5�   3   5�   /   5�   '   5�   #   �� 5�   "   $��2��5�   %   $��1��5�   %   $	 
Horizontal=�5�   %   #��[	 5�   %   .+�5�   &   �� #��[
 60     lblDelivery#���  6X   �� 5�   &   -   5         ��Name$ cBoxDeliveries��5�   )   $ 0��5�   )   $ 
DeliveryId��5�   )   #��[ 5�   )    5�   )   �� $ 
DeliveryId�$ TwoWay=�$ PropertyChanged=���5�   *     5�   .   �� 5�   2   -   5        $ DeliveryNumber��5�   5   $��Seleccione...��5�   5   $
 True��5�   5   �� 5�   2    6F   �� # [ 5�   /   ��5�   *   �� 5�   .   .R�5�   2   �� .+�5�   6   �� ��6@   �� $ DeliveryNumber�5�   3   5�   /   5�   '   5�   #   �� 5�   "   $��2��5�   %   $��2��5�   %   $	 
Horizontal=�5�   %   #��[	 5�   %   .+�5�   &   �� #��[
 60     lblBasculeType#���  6X   �� 5�   &   #��[ 60     lblBasculeTypeFloor#���  6R   5�   #   �� 5�   "   $��1��5�   %   $��2��5�   %   $	 
Horizontal=�5�   %   #��[	 5�   %   .+�5�   &   �� #��[
 60     lblFechaActual#���  6X   �� 5�   &   #��[ 60   ��6R   �� *DeliveryHeader.CurrentDate+5�   #   5�      5�      �� 5�      y�6%   �� $ 
DeliveryId�#
 [ .+�5�      9� -   5         9�Name$ ArticlesExpanded��5�   !   $��10q�5�   !   $��
Artículos��5�   !     ExpanderArticles#��[ 5�   !    9� 
IsExpanded 5�   !   �� $ 
IsExpanded�$ TwoWay=�$ PropertyChanged=�.��5�   "   &   System.Windows.Controls.DataGrid  -   5          Name$ dgDeliveryArticles��5�   %   $��2��5�   %   $��5��5�   %   $
��1024��5�   %      AutoGenerateColumns$ False��5�   %      CanUserAddRows$ False��5�   %      CanUserDeleteRows$ False��5�   %      CanUserReorderColumns$ False��5�   %      CanUserResizeColumns$
 True��5�   %   $   HorizontalScrollBarVisibility$ Disabled=�5�   %   $
��True��5�   %   ! �� IsDeferredScrollingEnabled$ False��5�   %   $��Disabled=�5�   %      SelectionMode$ Single=�5�   %      SelectionUnit$ FullRow=�5�   %   "    VerticalScrollBarVisibility$  Disabled=�5�   %   ��5�   %   �� *ArticlesToBeReceives+! �� SelectedItem! 5�   %   �� *ArticleSelected+  5�   &   �� 5�   *   %   &	         5�   .   6E   5�   +   ��5�   &   �� 5�   *   " �� 
TargetType)  #System.Windows.Controls.DataGridRow""  60   .�5�   .   �� # �� Property# � ��$ �� Value$ 6K   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=�5�   +   %   Columns% 5�   &   0  *System.Windows.Controls.DataGridTextColumn  5�   *   ,	  &System.Windows.Controls.DataGridColumn& 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$& 5*
 5�   -   ' 	  Header$' Código Artículo��5�   -   ( 	  
IsReadOnly$
( True��5�   -   1  +System.Windows.Controls.DataGridBoundColumn)   Binding) 5�   -   �� $ ArticleCode�* 	  HeaderTemplate* 5�   .   �� 5�   2   .R�5�   6   �� $	 Vertical=�6A   .+�5�   :   �� $
��Wrap=�6�   ��6D   �� *	Content++ �� RelativeSource+ �� , �� Mode$, TemplatedParent=�6�   �� 5�   :   ��6B   �� $# DataContext.FilterCodeArticle�$ TwoWay=�$ PropertyChanged=�+ �� *FindAncestor+- �� AncestorType"-  .��6�   .  (System.Windows.Interactivity.Interaction.   Triggers. 5�   >   /  )System.Windows.Interactivity.EventTrigger  5�   B   /   	EventName$/ KeyDown��6Q   .  (System.Windows.Interactivity.TriggerBase0   Actions.0 5�   F   /  )GalaSoft.MvvmLight.Command.EventToCommand  1   Command1 6Y   �� $/ )DataContext.FilterDeliveryArticlesCommand�+ �� *FindAncestor+"-  5�   C   .��5�   V   5�   ;   5�   7   5�   3   5�   +     5�   *   $	& 12*
 5�   -   $' Nombre��5�   -   $
( True��5�   -   ) 5�   -   �� $ ArticleName�* 5�   .   �� 5�   2   .R�5�   6   �� $	 Vertical=�6A   .+�5�   :   �� $
��Wrap=�6�   ��6D   �� *	Content++ �� $, TemplatedParent=�6�   �� 5   :   $	��200��6B   ��6Q   �� $# DataContext.FilterNameArticle�$ TwoWay=�$ PropertyChanged=�+ �� *FindAncestor+"-  .��6  . 5  >     5  B   $/ KeyDown��6Q   .0 5  F     1 6Y   �� $/ )DataContext.FilterDeliveryArticlesCommand�+ �� *FindAncestor+"-  5  C   .��5  V   5  ;   5  7   5  3   5
  +     5  *   $& 4*
 5  -   $' Estado��5  -   $
( True��5  -   ) 5  -   �� $ State�* 5  .   �� 5  2   .R�5  6   �� $	 Vertical=�6A   .+�5  :   �� $
��Wrap=�6�   ��6D   �� *	Content++ �� $, TemplatedParent=�6�   �� 5  :   ��6B   �� $$ DataContext.FilterStateArticle�$ TwoWay=�$ PropertyChanged=�+ �� *FindAncestor+"-  .��6�   . 5  >     5  B   $/ KeyDown��6Q   .0 5  F     1 6Y   �� $/ )DataContext.FilterDeliveryArticlesCommand�+ �� *FindAncestor+"-  5  C   .��5  V   5  ;   5  7   5  3   5   +     5"  *   $& 5*
 5#  -   $' Cantidad Solicitada��5%  -   $
( True��5&  -   ) 5$  -   �� $ QuantityRequested�#
 [ 2   ElementStyle2 5'  .   �� 5(  2   "" ��68   .�5)  6   �� # � ��$$ Right=�6\   5*  3   * 5,  .   �� 5-  2   .R�5.  6   �� $	 Vertical=�6A   .+�5/  :   �� $
��Wrap=�6�   ��6D   �� *	Content++ �� $, TemplatedParent=�6�   �� 50  :   ��6B   �� $( "DataContext.FilterQuantityDelivery�$ TwoWay=�$ PropertyChanged=�+ �� *FindAncestor+"-  .��6�   . 51  >     52  B   $/ KeyDown��6Q   .0 53  F     1 6Y   �� $/ )DataContext.FilterDeliveryArticlesCommand�+ �� *FindAncestor+"-  54  C   .��55  V   56  ;   57  7   58  3   5:  +     5<  *   $& 5*
 5=  -   $' Cantidad Aprobada��5?  -   $
( True��5@  -   ) 5>  -   �� $ QuantityAprobed�#
 [ 2 5A  .   �� 5B  2   "" ��68   .�5C  6   �� # � ��$$ Right=�6\   5D  3   * 5F  .   �� 5G  2   .R�5H  6   �� $	 Vertical=�6A   .+�5I  :   �� $
��Wrap=�6�   ��6D   �� *	Content++ �� $, TemplatedParent=�6�   �� 5J  :   ��6B   �� $( "DataContext.FilterQuantityDelivery�$ TwoWay=�$ PropertyChanged=�+ �� *FindAncestor+"-  .��6�   . 5K  >     5L  B   $/ KeyDown��6Q   .0 5M  F     1 6Y   �� $/ )DataContext.FilterDeliveryArticlesCommand�+ �� *FindAncestor+"-  5N  C   .��5O  V   5P  ;   5Q  7   5R  3   5T  +     5V  *   $& 5*
 5W  -   $' Cantidad Enviada��5Y  -   $
( True��5Z  -   ) 5X  -   �� $ QuantitySended�#
 [ 2 5[  .   �� 5\  2   "" ��68   .�5]  6   �� # � ��$$ Right=�6\   5^  3   * 5`  .   �� 5a  2   .R�5b  6   �� $	 Vertical=�6A   .+�5c  :   �� $
��Wrap=�6�   ��6D   �� *	Content++ �� $, TemplatedParent=�6�   �� 5d  :   ��6B   �� $( "DataContext.FilterQuantityDelivery�$ TwoWay=�$ PropertyChanged=�+ �� *FindAncestor+"-  .��6�   . 5e  >     5f  B   $/ KeyDown��6Q   .0 5g  F     1 6Y   �� $/ )DataContext.FilterDeliveryArticlesCommand�+ �� *FindAncestor+"-  5h  C   .��5i  V   5j  ;   5k  7   5l  3   5n  +   4  .System.Windows.Controls.DataGridTemplateColumn  5p  *   $& 5*
 6A   $' Cantidad Recibida��6L   3   CellTemplate3 5q  .   �� 5r  2   .R�5s  6   �� -   5        4 �� TextAlignment$4 Right=�5v  9   ��5u  9   �� $ QuantityReceive�$ TwoWay=�$ PropertyChanged=�#
 [ 5v  9   5w  3   * 5y  .   �� 5z  2   .R�5{  6   �� $	 Vertical=�6A   .+�5|  :   �� $
��Wrap=�6�   ��6D   �� *	Content++ �� $, TemplatedParent=�6�   �� 5}  :   ��6B   �� $( "DataContext.FilterQuantityDelivery�$ TwoWay=�$ PropertyChanged=�+ �� *FindAncestor+"-  5~  7   5  3   5�  +     5�  *   $& 4*
 5�  -   $' 	Ud Medida��5�  -   $
( True��5�  -   ) 5�  -   �� $ MeasureUnit�* 5�  .   �� 5�  2   .R�5�  6   �� $	 Vertical=�6A   .+�5�  :   �� $
��Wrap=�6�   ��6D   �� *	Content++ �� $, TemplatedParent=�6�   �� 5�  :   ��6B   �� $+ %DataContext.FilterUnitMeasureDelivery�$ TwoWay=�$ PropertyChanged=�+ �� *FindAncestor+"-  .��6�   . 5�  >     5�  B   $/ KeyDown��6Q   .0 5�  F     1 6Y   �� $/ )DataContext.FilterDeliveryArticlesCommand�+ �� *FindAncestor+"-  5�  C   .��5�  V   5�  ;   5�  7   5�  3   5�  +   5�  #   5�     �� 5�     -   5        $��stackContainers��5�  !   $	 
Horizontal=�5�  !   y�5�  !   �� $ ArticleSelected�#
 [ .+�5�  "   �� -	   5        5 ��Name$5 ContainersItemControl��5�  %   6 �� AlternationCount$	6 100��5�  %   ��5�  %   �� $ 
Containers�$ TwoWay=�$ PropertyChanged=���5�  &   �� 5�  *   .R�5�  .   A� 7 A� Columns7 6:   �� *Containers.Count+$ OneWay=�$ PropertyChanged=�5�  +   ��5�  &   �� 5�  *   .R�5�  .   � $��0,0,0,5q�63    5�  2   �� 5�  6   �� 5�  6    5�  2   �� 5�  6   .+�5�  2   �� $��0��5�  5   $��0��5�  5     
LabelStyle#��[ 5�  5   ��5�  5   �� $ ContainerLabel�5�  5   �� 5�  2   -
   5        $��1��5�  5   $��0��5�  5     TextBoxStyle#��[ 5�  5   $4 Right=�5�  5   ��5�  5   �� $ ContainerQuantity�$ TwoWay=�$ PropertyChanged=�.��5�  K   . 5�  6     5�  :   $/ KeyDown��6I   .0 5�  >     1 6Q   �� $" DataContext.UpdateContainers�+ �� *FindAncestor+"- ��5�  ;     5�  :   $/ 	LostFocus��6I   .0 5�  >     1 6Q   �� $" DataContext.UpdateContainers�+ �� *FindAncestor+"- ��5�  ;     5�  :   $/ TextChanged��6I   .0 5�  >     1 6Q   �� $" DataContext.UpdateContainers�+ �� *FindAncestor+"- ��5�  ;   .��5�  N   5�  3   5�  /   5�  +   5�  #   5�     �� 5�     $��0��5�  !   $��1��5�  !   $��0,30,0,0q�5�  !   #��[	 5�  !   .+�5�  "   �� #��[
 6,     lblSumaryWeight#���  6T   �� 5�  "   #��[ 6,   ��6N   �� $ ContainersTotalWeight�$ TwoWay=�$ PropertyChanged=�#
 [ 5�     �� 5�     $��0��5�  !   $��1��5�  !   $��0,-30,100,0q�5�  !   $��Right=�5�  !   #��[	 5�  !   .+�5�  "   ��   TextHeaderViewBascule#��[ 6,     lblBasculeWeight#���  6[   5�     �� 5�     $��1��5�  !   $��1��5�  !   $��	0,0,100,0q�5�  !   $��Right=�5�  !   #��[	 5�  !   .+�5�  "   ��   DataTextBascule#��[ 5�  %   ��5�  %   �� $ WeighingBasculeState�$ TwoWay=�$ PropertyChanged=�#
 [ ��5�  %   �� $ WeighingBascule�$ TwoWay=�$ PropertyChanged=�#
 [ 5�     �� 5�     $
��0,30q�6)   y�67   �� $ ArticleSelected�#
 [ .+�5�  "   �� #��[
 6,     lblWeighingByBascule#���  6T   �� 5�  "   $��	10,0,10,0q�6-   $��30q�6@   .@�5�  &   �� $��10q�5�  )   
�������$��DemiBold"�5�  )   ���#7F0E06$��Peso Arrume al 8��5�  )   . 5�  *     5�  .   $/ MouseLeftButtonUp��6=   .0 5�  2     1 6E   �� *CmdAtEightSelected+5�  /   .��5�  *   �� .+�5�  .     -   5        $ dgWeighingsAtEight��5�  1   $��2��5�  1   $��5��5   1   $
��Auto��5  1   $ False��5  1   $ False��5  1   $ False��5  1   $ False��5  1   $
 True��5  1   $ Single=�5	  1   $ FullRow=�5
  1   ��5  1   �� *WeighingDetail+! 5  1   �� *ArticleBeingWeighing+��5  2   �� 5  6   ""  6<   .�5  :   �� # � ��$ 6W   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=�5  7   % 5  2     5  6   $& 2*
 6M   $' Peso Báscula��6X   3 5  :   �� 5  >   .R�5  B   �� $��Center=�5  E   $4 Right=�5  E   ��5  E   �� $ BasculeWeight�#
 [ $ TwoWay=�$ PropertyChanged=�.��5  [   . 5  F     5  J   $/ TextChanged��6Y   .0 5  N     1 6a   �� $&  DataContext.BasculeWeightChanged�+ �� *FindAncestor+"-  5  K   .��5  ^   5  C   5  ?   5   7     5"  6   $& 2*
 5#  9   $' Peso Total Artículo��5$  9   $
( True��5%  9   3 5&  :   �� 5'  >   .R�5(  B   �� $��2��5)  E   $��3��5*  E   $��Right=�5+  E   $��Center=�5,  E   ��5-  F   `� 5.  J   8 �� StringFormat$8 	 {0} {1} ��6W   .1�5/  N   �� #
 [ 50  Q   $ TwoWay=�51  Q   $ ArticleWeight�52  Q   $ PropertyChanged=�53  Q   �� 54  N   $ TwoWay=�55  Q   $ MeasureUnit�56  Q   $ PropertyChanged=�57  Q   58  K   5:  C   5;  ?   5=  7     5>  6   $& 6*
 5?  9   $' Detalle Contenedores��5@  9   $
( True��5A  9   3 5B  :   �� 5C  >   .R�5D  B   �  5E  F   �� 5F  J   $��* �6[   �� 5G  J   $	��100 �6[    5I  F   �� 5J  J   �� 5K  J   .+�5N  F   �� $��0��5O  I   $��0��5P  I   $��0q�5Q  I   $
��Left=�5R  I   $	��Top=�5S  I   $��Contenedores��5T  I   $��13(�5U  I   #��[ 5V  I   �� 5W  F   $��icContainers��5X  I   $��1��5Y  I   $��0��5Z  I   ��5[  I   �� $ 
Containers�$ TwoWay=�$ PropertyChanged=���5\  J   �� 5]  N   .R�5^  R   � $��5,0,0,5q�6W    5_  V   �� 5`  Z   $��* �6k   �� 5a  Z   $��* �6k    5c  V   �� 5d  Z   .+�5f  V   �� $��0��5g  Y   $��0��5h  Y   ��5i  Y   �� *ContainerLabel+�� 5j  V   $��0��5k  Y   $��1��5l  Y   ��5m  Y   �� *ContainerQuantity+$ TwoWay=�$ PropertyChanged=�$8 Cantidad: {0}��5n  S   5p  O   5r  G   �� 5s  F   $��0��5t  I   $��1��5u  I   $��0q�5v  I   $��Center=�5w  I   $	��Top=�5x  I   $��
Peso Total��5y  I   $��13(�5z  I   #��[ 5{  I   �� 5|  F   $��1��5}  I   $��1��5~  I   $��Center=�5  I   .+�5�  J   �� 9 �� TextAlignment$9 Right=�6�   ��6T   �� *ContainersTotalWeight+$ TwoWay=�$ PropertyChanged=�#
 [ $8  {0} KG��6�   5�  G   5�  C   5�  ?   5�  7   5�  /   �� 5�  .   -   5        $ btnAddWeighingAtEight��5�  1   $	��200��5�  1   $��
15,15,0,15q�5�  1   $
��Left=�5�  1   ���#4ACF50���#4ACF50$��Agregar Registro��5�  1   ��5�  1   �� *!SaveWeighingConfirmationCommand+{�5�  1   �� *
EnableSave+�� 5�  .   $��
0,-20,0,30q�5�  1   $
��Left=�5�  1   $��Bottom=�5�  1   $	 
Horizontal=�5�  1   y�5�  1   �� $ EnableSaveFalse�$ TwoWay=�$ PropertyChanged=�#
 [ .+�5�  2   ��   InfoDataText#��[ 6<   $<��6La entrega ya fue recibida y no puede recibir pesajes.��6b   5�  /   �� 5�  .   y�69   �� $ ArticleSelected�#
 [ .+�5�  2   �  5�  6   �� 5�  :   �� 5�  :    5�  6   �� 5�  :   .+�5�  6   �� $��0��6A   $��0��6N   .+�5�  :   ��   TextTotalView#��[ 6D     lblTotalWeightByBascule#���  6k   5�  7   �� 5�  6   $��0��6A   $��1��6N   .+�5�  :   �� #��[ 6D   ��6f   �� $ TotalWeightByBascule�$ TwoWay=�$ PropertyChanged=�#
 [ 5�  7   5�  3   5�  /   5�  +   5�  '   �� 5�  &   $��10q�5�  )   
�������$��DemiBold"�5�  )   ���#7F0E06$��Peso Arrume al 5��5�  )   . 5�  *     5�  .   $/ MouseLeftButtonUp��6=   .0 5�  2     1 6E   �� *CmdAtFiveSelected+5�  /   .��5�  *   �� .+�5�  .     -   5        $ dgWeighingsAtFive��5�  1   $��2��5�  1   $��5��5�  1   $
��Auto��5�  1   $ False��5�  1   $ False��5�  1   $ False��5�  1   $ False��5�  1   $
 True��5�  1   $ Single=�5�  1   $ FullRow=�5�  1   ��5�  1   �� *WeighingDetailAtFive+! 5�  1   �� *ArticleBeingWeighing+��5�  2   �� 5�  6   ""  6<   .�5�  :   �� # � ��$ 6W   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=�5�  7   % 5�  2     5�  6   $& 2*
 6M   $' Peso Báscula��6X   3 5�  :   �� 5�  >   .R�5�  B   �� $��Center=�5�  E   $4 Right=�5�  E   ��5�  E   �� $ BasculeWeight�#
 [ $ TwoWay=�$ PropertyChanged=�.��5�  [   . 5�  F     5�  J   $/ TextChanged��6Y   .0 5�  N     1 6a   �� $&  DataContext.BasculeWeightChanged�+ �� *FindAncestor+"-  5�  K   .��5�  ^   5�  C   5�  ?   5�  7     5�  6   $& 2*
 5�  9   $' Peso Total Artículo��5�  9   $
( True��5�  9   3 5�  :   �� 5�  >   .R�5�  B   �� $��2��5�  E   $��3��5�  E   $��Right=�5�  E   $��Center=�5�  E   ��5�  F   `� 5�  J   $8 	 {0} {1} ��6W   .1�5�  N   �� #
 [ 5�  Q   $ TwoWay=�5�  Q   $ ArticleWeight�5�  Q   $ PropertyChanged=�5�  Q   �� 5�  N   $ TwoWay=�5�  Q   $ MeasureUnit�5�  Q   $ PropertyChanged=�5�  Q   5�  K   5�  C   5�  ?   5�  7     5�  6   $& 6*
 5�  9   $' Detalle Contenedores��5�  9   $
( True��5   9   3 5  :   �� 5  >   .R�5  B   �  5  F   �� 5  J   $��* �6[   �� 5  J   $	��100 �6[    5  F   �� 5	  J   �� 5
  J   .+�5  F   �� $��0��5  I   $��0��5  I   $��0q�5  I   $
��Left=�5  I   $	��Top=�5  I   $��Contenedores��5  I   $��13(�5  I   #��[ 5  I   �� 5  F   $��icContainers��5  I   $��1��5  I   $��0��5  I   ��5  I   �� $ 
Containers�$ TwoWay=�$ PropertyChanged=���5  J   �� 5  N   .R�5  R   � $��5,0,0,5q�6W    5  V   �� 5  Z   $��* �6k   �� 5   Z   $��* �6k    5"  V   �� 5#  Z   .+�5%  V   �� $��0��5&  Y   $��0��5'  Y   ��5(  Y   �� *ContainerLabel+�� 5)  V   $��0��5*  Y   $��1��5+  Y   ��5,  Y   �� *ContainerQuantity+$ TwoWay=�$ PropertyChanged=�$8 Cantidad: {0}��5-  S   5/  O   51  G   �� 52  F   $��0��53  I   $��1��54  I   $��0q�55  I   $��Center=�56  I   $	��Top=�57  I   $��
Peso Total��58  I   $��13(�59  I   #��[ 5:  I   �� 5;  F   $��1��5<  I   $��1��5=  I   $��Center=�5>  I   .+�5?  J   �� $9 Right=�6�   ��6T   �� *ContainersTotalWeight+$ TwoWay=�$ PropertyChanged=�#
 [ $8  {0} KG��6�   5@  G   5B  C   5C  ?   5E  7   5G  /   �� 5H  .   -   5        $ btnAddWeighingAtFive��5I  1   $	��200��5J  1   $��
15,15,0,15q�5K  1   $
��Left=�5L  1   ���#4ACF50���#4ACF50$��Agregar Registro��5P  1   ��5O  1   �� *!SaveWeighingConfirmationCommand+{�5Q  1   �� *
EnableSave+�� 5R  .   $��
0,-20,0,30q�5S  1   $
��Left=�5T  1   $��Bottom=�5U  1   $	 
Horizontal=�5V  1   y�5W  1   �� $ EnableSaveFalse�$ TwoWay=�$ PropertyChanged=�#
 [ .+�5X  2   �� #��[ 6<   $<��6La entrega ya fue recibida y no puede recibir pesajes.��6b   5Y  /   �� 5Z  .   y�69   �� $ ArticleSelected�#
 [ .+�5[  2   �  5\  6   �� 5]  :   �� 5^  :    5`  6   �� 5a  :   .+�5d  6   �� $��0��6A   $��0��6N   .+�5e  :   �� #��[ 6D   #���  6k   5f  7   �� 5g  6   $��0��6A   $��1��6N   .+�5h  :   �� #��[ 6D   ��6f   �� $ TotalWeightByBascule�$ TwoWay=�$ PropertyChanged=�#
 [ 5i  7   5k  3   5l  /   5m  +   5o  '   5p  #   5q     �� 5r     $
��0,30q�6)   y�67   �� $ ArticleSelected�#
 [ .+�5s  "   �� #��[
 6,     lblWeighingByBarCode#���  6T     5u  "   -   5        $ dgWeighingsBarCode��5v  %   $��2��5w  %   $��5��5x  %   $��1024 ��5y  %   $ False��5z  %   $ False��5{  %   $ False��5|  %   $ False��5}  %   $
 True��5~  %   $ Single=�5�  %   $ FullRow=�5�  %   ��5  %   �� *BarCodeDetails+$ TwoWay=�$ PropertyChanged=�! 5�  %   �� *ArticleBarCodeToRead+  5�  &   �� 5�  *   %   &	         5�  .   6E   5�  +   ��5�  &   �� 5�  *   ""  60   .�5�  .   �� # � ��$ 6K   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=�5�  +   % 5�  &     5�  *   $	& 10*
 6A   $' Código de Barras��6M   3 5�  .   �� 5�  2   .R�5�  6   �� ��6>   �� $ BarCode�$ TwoWay=�$ PropertyChanged=�.��6�   . 5�  :     5�  >   $/ 	LostFocus��6M   .0 5�  B     1 6U   �� $&  DataContext.BarCodeReadedCommand�+ �� *FindAncestor+"-  5�  ?   .��5�  R   5�  7   5�  3   5�  +     5�  *   $& 5*
 5�  -   $' Código Artículo��5�  -   $
( True��5�  -   ) 5�  -   �� $ ArticleCode�5�  -     5�  *   $& 5*
 5�  -   $' Nombre��5�  -   $
( True��5�  -   ) 5�  -   �� $ ArticleName�5�  -     5�  *   $& 5*
 5�  -   $
' Lote��5�  -   $
( True��5�  -   ) 5�  -   �� $	 Lot�2 5�  .   �� 5�  2   "" ��68   .�5�  6   �� # � ��$$ Right=�6\   5�  3   5�  +     5�  *   $& 5*
 5�  -   $' Estado��5�  -   $
( True��5�  -   ) 5�  -   �� $ ArticleState�5�  -     5�  *   $& 5*
 5�  -   $' Fecha de Vencimiento��5�  -   $
( True��5�  -   ) 5�  -   �� $ ExpirationDate�5�  -     5�  *   $& 5*
 5�  -   $' Unidades por Contenedor��5�  -   $
( True��5�  -   ) 5�  -   �� $ ArticleQuantity�2 5�  .   �� 5�  2   "" ��68   .�5�  6   �� # � ��$$ Right=�6\   5�  3   5�  +     5�  *   $& 5*
 5�  -   $' Peso Código de Barras��5�  -   $
( True��5�  -   ) 5�  -   �� $ Weight�#
 [ 5�  -     5�  *   $& 5*
 5�  -   $' 	Ud Medida��5�  -   $
( True��5�  -   ) 5�  -   �� $ MeasureUnit�5�  -   5�  #   5�     �� 5�     y�6)   �� $ ArticleSelected�#
 [ .+�5�  "   �  5�  &   �� 5�  *   �� 5�  *    5�  &   �� 5�  *   .+�5�  &   �� $��0��61   $��0��6>   .+�5�  *   �� #��[ 64      lblTotalWeightByBarCode#���   6[   5�  '   �� 5�  &   $��0��61   $��1��6>   .+�5�  *   �� #��[ 64   ��6V   �� $ TotalWeightByBarCode�$ TwoWay=�$ PropertyChanged=�#
 [ 5�  '   5�  #   5�     5�     �� 5�     $��0q�5�     $
��Left=�5�     $��Bottom=�5�     $	 
Horizontal=�5�     y�5�     �� $ ThereAreDifferences�$ TwoWay=�$ PropertyChanged=�#
 [ .+�5�     �� #��[ 6(   $e��_*Hay diferencia entre el pesaje de báscula y el peso de los códigos de barra para este pesaje��6N   5�     �� 5�     $
��0,20q�5�     $��Right=�5�     $��Bottom=�5�     $	 
Horizontal=�5�     y�5�     �� $ 
DeliveryId�#
 [ .+�5�     �� -   5        $ btnSave��5�  !   $��0,0,5,0q�5�  !   ���#4ACF50���#4ACF50$��Confirmar Recepción��5  !   ��5   !   �� *!ConfirmReceiveByDeliveryCommand+{�5  !   �� *
EnableSave+5     �� 5     $��
0,-20,0,30q�5     $��Right=�5     $��Bottom=�5     $	 
Horizontal=�5     y�5	     �� $ EnableSaveFalse�$ TwoWay=�$ PropertyChanged=�#
 [ .+�5
     �� #��[ 6(   $!��La entrega ya fue recibida.��6N   5     5     5     5     � 5      ! IconCard#��[! 6   : J� Effect: 5     3  -System.Windows.Media.Effects.DropShadowEffect  5     ;   
BlurRadius$; 20Q�5     <   RenderingBias$< Quality=�5     =   ShadowDepth$= 1Q�5     >   Color$> 	#FFECECEC��5     .+�5     ��  " 
BorderCard#��[" 6   '  !MaterialDesignThemes.Wpf.PackIcon  5     $��30��5     $��30��5     $��5q�5     $��10q�5     $��Center=�5     $��Center=�5      
�������?   Kind$? PlaylistAddCheck=�5"     5#     � 5$      	# Title#��[# 6   .+�5%     ��  $ ContentTitle#��[$ 6   .+�5&     ��  % 	TextTitle#��[% 6    $6��0Plantilla Recepción de Mercancia Punto de Venta��6C   5'     5(     5)     5+     5-     