   M S B A M L   `   `   `  ����A  =EVO_PV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EVO_PV.UtilitiesEVO_PV.Utilities  5      "    EVO_PV.Views.UCOrderListEdit   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      *localclr-namespace:EVO_PV.Utilities  5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      -   5          >�Name$  UserControl��5      $
|�True��5       � 	Resources 5       �� MergedDictionaries �� Source   StatesArticle �� Source �� Path �� Mode �� UpdateSourceTrigger  Packages  VisibilityConverterBool�� 5   
    5      �� 5      $< 6/EVO_PV;Component/Resources/Dictionaries/DictTags.xaml?�6%   �� 5      $2 ,/EVO_PV;Component/Resources/Style/style.xaml?�6%   %�   &	        &	 S     &	 �     �� 5       69   �� $ StatesArticle�$ TwoWay=�$ PropertyChanged=��� 5       64   �� $ Packages�$ TwoWay=�$ PropertyChanged=��� 5      6+   5      .��5      � ���#eee � ColumnDefinitions 5   
   �� 5       $��* �6   	 � RowDefinitions	 5#   
   �� 5$      $��70 �6   �� 5%      .+�5'   
   �� y�6   �� $ IsOnDuplyState�$ TwoWay=�$ PropertyChanged=�
 �� 	Converter#
 [ .+�5(      �� $��0��5)      $	��150��5*      $��0,0,40,0q�5+      $��0q�5,      $��Right=�5-      $	��Top=�5.      ���#00BCD4���#00BCD4 " MaterialDesignRaisedDarkButton#��[ 52      ��51      �� $ ViewDetails�.��53      � $	��150��6   $��Center=�6#   .+�54      '  !MaterialDesignThemes.Wpf.PackIcon  $��10,2,0,0q�55      ���#FFFFFF   Kind$ ChevronLeft=�57      �� 58      $��Center=�6    $��REGRESAR��6=   59      5:      5;      �� 5<   
   y�6   �� $ IsNotDuplyState�$ TwoWay=�$ PropertyChanged=�#
 [ .+�5=      �� $��0��5>      $	��150��5?      $��0,0,40,0q�5@      $��0q�5A      $��Right=�5B      $	��Top=�5C      ���#00BCD4���#00BCD4#��[ 5G      ��5F      �� $ ViewDetails�y�5H      �� $ IsNotCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ .��5I      � $	��150��6   $��Center=�6#   .+�5J        $��10,2,0,0q�5K      ���#FFFFFF$ ChevronLeft=�5M      �� 5N      $��Center=�6    $��REGRESAR��6=   5O      5P      �� 5Q      $��0��5R      $	��150��5S      $��0,0,40,0q�5T      $��0q�5U      $��Right=�5V      $	��Top=�5W      ���#00BCD4���#00BCD4#��[ 5[      ��5Z      �� $ ViewDetailsCraft�y�5\      �� $ IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ .��5]      � $	��150��6   $��Center=�6#   .+�5^        $��10,2,0,0q�5_      ���#FFFFFF$ ChevronLeft=�5a      �� 5b      $��Center=�6    $��REGRESAR��6=   5c      5d      5e      � 5h   
   $��1��6   $
��Auto��6   .+�5i      #  MaterialDesignThemes.Wpf.Card  $��1��6"   $��
30,0,30,10q�6/   .��5j      �   ContentCard#��[ 6   .+�5k      �� .+�5m      �� .+�5n      � $��	0,10,0,20q�6#    5o   "   �� 5p   &   $��1* �67   �� 5q   &   $��1* �67   �� 5r   &   $��1* �67   	 5t   "   �� 5u   &   .+�5x   "   �� $��0��5y   %   $��0��5z   %     
HeaderView#��[ 5{   %   .+�5|   &   ��   TextHeaderView#��[ 60     lblDateRequest#���  6X   �� 5}   &     DateCreation#��[ 60   ��6V   �� $ PropertyChanged=� �� StringFormat$ 
dd/MM/yyyy��$ 	DateOrder� �� ValidatesOnDataErrors$
 True�� �� NotifyOnValidationError$
 True��$ OneWay=�5~   #   �� 5   "   $��0��5�   %   $��1��5�   %   #��[ 5�   %   .+�5�   &   �� #��[ 60    	 lblDateDelivery#��� 	 6X   �� 5�   &   #��[ 5�   )   ��5�   )   �� $ PropertyChanged=�$ 
dd/MM/yyyy��$ DateDelivery�$
 True��$
 True��$ OneWay=�y�5�   )   �� $ IsNotCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ (  "System.Windows.Controls.DatePicker  5�   &   -   5        $��dpDateDelivery��5�   )   $	��110��5�   )   $��
10,-4,-1,0q�5�   )   $��Bottom=�5�   )   ���	#FFECECEC$|�False��5�   )      IsTodayHighlighted$ False��5�   )    � Language$ ES-mx�5�   )      DisplayDateStart 5�   )   �� $ 	DateOrder�$ TwoWay=�   IsDropDownOpen 5�   )   �� $
 Open�   SelectedDate 5�   )   �� $ DateDelivery�$ TwoWay=�$
 True��$
 True��$ 	LostFocus=�y�5�   )   �� $ IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [  5�   *    
 PrimaryHueMidBrush �� Color  MaterialDesignBody��%T   &	
       &	 !     �� 5�   .   $ #FF9800��6Y   �� 5�   .   $ Black��6Y   5�   +   5�   '   5�   #   �� 5�   "   $��0��5�   %   $��2��5�   %   #��[ 5�   %   .+�5�   &   �� #��[ 60     lblRequestFor#���  6X   �� 5�   &   #��[ 5�   )   $��Área de Compras��5�   )   y�5�   )   �� $ IsPurchaseOrder�$ TwoWay=�$ PropertyChanged=�#
 [ �� 5�   &   -   5         ��Name$ 	cbPlantas��5�   )    �� DisplayMemberPath$ WhsName��5�   )   ${�False��5�   )    �� SelectedValuePath$ WhsCode��5�   )     ComboBoxStyle#��[ 5�   )   ��5�   )   �� $ 	Factories� �� SelectedValue 5�   )   �� $ FactoryCode�$ TwoWay=�$ PropertyChanged=�y�5�   )   �� $ IsNotPurchaseOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 5�   #   5�      5�      �� 5�       5�        ProxyElement � DataContext��%&   &	       � 5�   "    6H   �� 5�      .+�5�      �� #��[ 6-   $y�	Collapsed=�6U   &   System.Windows.Controls.DataGrid  5�      -   5          Name$ dgOrderArticlesHide��5�   !   $��2��5�   !   $��4��5�   !   $
��1020��5�   !   $	��320��5�   !      AutoGenerateColumns$ False��5�   !      CanUserAddRows$ False��5�   !      CanUserDeleteRows$ False��5�   !      CanUserReorderColumns$ False��5�   !      CanUserResizeColumns$
 True��5�   !   $
��True��5�   !   $
��Auto=�5�   !       SelectionMode$  Single=�5�   !   !   SelectionUnit$! FullRow=�5�   !   ��5�   !   �� *ArticlesOrder+" �� SelectedItem" 5�   !   �� *ArticleOrderSelected+y�5�   !   �� $ IsNotCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [  5�   "   '   !EVO_PV.Utilities.DecimalConverter  decimalConverter�� 5�   &   %:   &	       &	        5�   *   6A   �� 5�   *   6G   5�   '   ��5�   "   �� 5�   &   # �� 
TargetType)  #System.Windows.Controls.DataGridRow"#  6,   .�5�   *   �� $ �� Property$ � ��% �� Value% 6G   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=��� 5�   *   $ � ��$% 0,0,0,0q�6C   �� 5�   *   $ � ��$% 0q�6L   5�   '   &   ColumnHeaderStyle& 5�   "   �� 5�   &   =  7System.Windows.Controls.Primitives.DataGridColumnHeader"#  6,   .�5�   *   �� $ � ��$% 80��6C   �� 5�   *   $ � ��
% �����6H   �� 5�   *   $ � ��$% 0q�6L   �� 5�   *   $ � ��$% 0,0,0,50q�6C   �� 5�   *   $ � ��% �#7F0E066G   �� 5�   *   $ � ��$% Bottom=�6U   �� 5�   *   $ � ��$% DemiBold"�6G   ' �� 	Resources' 5�   *   ��%  '��       '��     �� 5�   .   "# ��64   .�5�   2   �� $ � ��
% �   �6O   �� 5�   2   $ � ��$% 0,0,0,1q�6T   �� 5�   2   $ � ��
% �   �6P   �� 5�   2   $ � ��$% 5q�6L   �� 5�   2   $ � ��$% 0,10,0,0q�6K   �� 5�   2   $ � ��$% Normal"�6O   5�   /   �� 5�   .   "# ��64   .�5�   2   �� $ � ��
% �   �6O   �� 5�   2   $ �@��Padding$% 5q�6L   �� 5�   2   $ � ��$% 0,10,0,0q�6K   �� 5�   2   $ � ��$	% Top=�6V   �� 5�   2   $ � ��$% Normal"�6O   5�   /   5�   +   5�   '   (   RowStyle( 5�   "   �� 5�   &   "#  6,   .�5�   *   �� $ � ��$
% Auto��6C   �� 5�   *   $ � ��% 6G   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=��� 5�   *   $ � ��$% 0,0,0,0q�6C   �� 5�   *   $ � ��$% 0q�6L   5�   '   )   Columns) 5�   "   0  *System.Windows.Controls.DataGridTextColumn  5�   &   ,	  &System.Windows.Controls.DataGridColumn* 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	* 26*
 5   )   + 	  Header$+ Código Artículo��5  )   , 	  
IsReadOnly$
, True��5  )   1  +System.Windows.Controls.DataGridBoundColumn-   Binding- 5  )   �� $ CodeArticle�. 	  HeaderTemplate. 5  *   �� 5  .   .R�5  2   �� / �� Orientation$/ Vertical=�6=   .+�5  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� RelativeSource0 �� 1 �� Mode$1 TemplatedParent=�6�   5  3   5	  /   2   ElementStyle2 5  *   �� 5  .   "# ��64   .�5  2   �� $ � ��$% Center=�6V   5  /   5  '     5  &   $	* 40*
 5  )   $+ Nombre��5  )   $
, True��5  )   - 5  )   �� $ NameArticle�. 5  *   �� 5  .   .R�5  2   �� $/ Vertical=�6=   .+�5  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   5  3   5  /   2 5  *   �� 5  .   "# ��64   .�5   2   �� $ � ��$% Center=�6V   5!  /   5#  '   4  .System.Windows.Controls.DataGridTemplateColumn  5$  &   $	* 25*
 6=   $+ Cantidad��6I   3   CellTemplate3 5%  *   �� 5&  .   .R�5'  2   �� $��Center=�6=   .+�5(  6   �� -   5        4 �� TextAlignment$4 Right=�5,  9   ��5+  9   �� $ Quantity�$ {0:n2}��$ TwoWay=�$ PropertyChanged=�#
 [ 5,  9   5-  3   5.  /   . 51  *   �� 52  .   .R�53  2   �� $/ Vertical=�6=   .+�54  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   55  3   56  /   58  '   4  .System.Windows.Controls.DataGridComboBoxColumn  5:  &   $	* 25*
 5;  )   5   DisplayMemberPath$
5 Name��5<  )   $+ Estado��5=  )   6   SelectedValuePath$6 StateArticleId��5?  )   7   SelectedValueBinding7 5>  )   �� $ StateArticleId�$ TwoWay=�8 	  
Visibility8 5@  )   �� * DataContext.IsNotPurchaseOrder+9 �� Source#9 [    BooleanToVisibilityConverter#
 [ . 5A  *   �� 5B  .   .R�5C  2   �� $/ Vertical=�6=   .+�5D  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   5E  3   5F  /   :   ElementStyle: 5H  *   �� 5I  .   "# ��64   .�5J  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+; �� AncestorType";  $ DataContext.StatesArticle��� 5K  2   $ � ��$% Center=�6V   5L  /   <   EditingElementStyle< 5N  *   �� 5O  .   "# ��64   .�5P  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+";  $ DataContext.StatesArticle�5Q  /   5S  '     5T  &   $	* 25*
 5U  )   $5 PackageName��5V  )   $+ Empaque��5W  )   $6 	PackageId��5Y  )   7 5X  )   �� $ 	PackageId�$ TwoWay=�8 5Z  )   �� * DataContext.IsNotPurchaseOrder+#9 [ #
 [ . 5[  *   �� 5\  .   .R�5]  2   �� $/ Vertical=�6=   .+�5^  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   5_  3   5`  /   : 5b  *   �� 5c  .   "# ��64   .�5d  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+";  $ DataContext.Packages��� 5e  2   $ � ��$% Center=�6V   5f  /   < 5h  *   �� 5i  .   "# ��64   .�5j  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+";  $ DataContext.Packages�5k  /   5m  '     5o  &   $	* 25*
 5p  )   $+ Unidad de Medida��5r  )   $
, True��5s  )   - 5q  )   �� $ UnitMeasure�. 5t  *   �� 5u  .   .R�5v  2   �� $/ Vertical=�6=   .+�5w  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   5x  3   5y  /   2 5{  *   �� 5|  .   "# ��64   .�5}  2   �� $ � ��$% Center=�6V   5~  /   5�  '     5�  &   $	* 25*
 5�  )   $+ Pedido Sugerido��5�  )   $
, True��5�  )   - 5�  )   �� $ SuggestedOrder�#
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   5�  3   5�  /   2 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��$% Center=�6V   �� 5�  2   $ � ��$% Right=�6X   5�  /   5�  '     5�  &   $	* 25*
 5�  )   $+ Stock��5�  )   $
, True��5�  )   - 5�  )   �� $ Stock�#
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   5�  3   5�  /   2 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��$% Center=�6V   �� 5�  2   $ � ��$% Right=�6X   5�  /   5�  '     5�  &   $	* 25*
 5�  )   $+ Mínimo��5�  )   $
, True��5�  )   - 5�  )   �� $ Minimum�#
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   5�  3   5�  /   2 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��$% Center=�6V   �� 5�  2   $ � ��$% Right=�6X   5�  /   5�  '     5�  &   $	* 25*
 5�  )   $+ Máximo��5�  )   $
, True��5�  )   - 5�  )   �� $ Maximum�#
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   5�  3   5�  /   2 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��$% Center=�6V   �� 5�  2   $ � ��$% Right=�6X   5�  /   5�  '     5�  &   $	* 30*
 6=   $+ Observaciones��6I   . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   5�  3   5�  /   3 5�  *   �� 5�  .   .R�5�  2   �� .+�5�  6   � $��41��5�  9   $��60��5�  9   $��41��5�  9   $
��Left=�5�  9   = � ToolTip= 5�  9   �� *Observations+$ TwoWay=�$ PropertyChanged=�.+�5�  :   �� $
��Wrap=�6�   ��6D   �� *Observations+$ TwoWay=�$ PropertyChanged=���5�  >   �� 5�  B   "# ��6H   .�5�  F   �� $ � ��$
% Wrap=�6e   �� 5�  F   $ � ��$% 11(�6a   �� 5�  F   $ � ��% �#0006c   5�  C   = 5�  >   _� 5�  B     CustomToolTip#��[ 6�    6J   �� 0 �� *Self+$ PlacementTarget.Parent�.��5�  F   �� ��6P   �� $ ToolTip���5�  J   �� 5�  N   "# ��6T   .�5�  R   �� $ � ��$
% Wrap=�6q   �� 5�  R   $ � ��$
% Auto��6k   �� 5�  R   $ � ��$% 15(�6m   5�  O   5�  G   5�  C   5�  ;   5�  7   �� 5�  6   $��20��5�  9   $��20��5�  9   $��-10,-20,-10,0q�5�  9   $��0q�5�  9   $��Right=�5   9   ���#FF9800���#FF9800��5  9   �� $, &DataContext.CmdOpenEditObservationItem�0 �� *FindAncestor+";  ��5  9   �� $ .�.��5  :     $��Center=�6R   $
 Edit=�6o   5  7   � 5  6   > �Name$> 	InfoPopup��5  9   ? � AllowsTransparency$
? True��5	  9   $��Bottom=�5  9   @ � 	StaysOpen$@ False��5  9   ��5
  9   �� *IsPopObservationOpen+$ TwoWay=�$ PropertyChanged=�.��5  :   �� A ��Name$A InfoPopupBorder��5  =   $	��200��5  =   $	��100��5  =   B K� ZIndex$B 10��5  =   
�������
�������$��1q�5  =   C �� CornerRadius$C 5��5  =   D J� EffectD 5  >   3  -System.Windows.Media.Effects.DropShadowEffect  5  B   E   
BlurRadius$E 10Q�5  E   F   	Direction$	F 270Q�5  E   G   Opacity$	G 0.5Q�5  E   H   ShadowDepth$H 7Q�5  E   ._�5  >   �� I ��Name$I TextAreaPopup��5  A   J �� AcceptsReturn$
J True��5  A   
�������K �� TextWrapping$
K Wrap=�5"  A   "L �� VerticalScrollBarVisibility$L Visible=�5#  A   ��5!  A   �� *Observations+$ TwoWay=�$ PropertyChanged=�5#  A   5$  ;   5%  7   5&  3   5'  /   5)  '     5+  &   $	* 25*
 6=   8 6I   �� *DataContext.IsCraftOrder+#9 [ #
 [ . 5,  *   �� 5-  .   .R�5.  2   �� $/ Vertical=�6=   .+�5/  6   �� $��20,0,0,5q�50  9   $��Agregar��51  9   $
��Wrap=�52  9   y�53  9   �� $ DataContext.IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 0 �� *FindAncestor+";  �� 54  6   $��30��55  9   $��30��56  9   $��25,0,5,0q�57  9   $��0q�58  9   $��Center=�59  9   $��Center=�5:  9   ���#4CAF50���#4ACF50$��13q�5=  9   ��5>  9   �� $, &DataContext.ValidateFindArticleCommand�0 �� *FindAncestor+";  y�5?  9   �� $ DataContext.IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 0 �� *FindAncestor+";  .��5@  :     $��Center=�6R   $	 Add=�6o   5A  7   5B  3   5C  /   3 5E  *   �� 5F  .   .R�5G  2   �� $��Center=�5H  5   $��Center=�5I  5   $/ 
Horizontal=�5J  5   .+�5K  6   �� $��30��5L  9   $��30��5M  9   $��5,0,5,0q�5N  9   $��0q�5O  9   $��Center=�5P  9   $��Center=�5Q  9   
���  ��
���  ��$��13q�5T  9   ��5U  9   �� $+ %DataContext.DeleteArticleOrderCommand�0 �� *FindAncestor+";  y�5V  9   �� $ DataContext.IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 0 �� *FindAncestor+";  .��5W  :     $��Center=�6R   $ Trash=�6o   5X  7   5Y  3   5Z  /   5\  '   5_       5`     -   5        $ dgOrderArticles��5a  !   $��2��5b  !   $��4��5c  !   $
��1020��5d  !   $	��320��5e  !   $ False��5f  !   $ False��5g  !   $ False��5h  !   $ False��5i  !   $
 True��5j  !   $
��True��5m  !   $
��Auto=�5n  !   $  Single=�5p  !   $! FullRow=�5q  !   ��5l  !   �� *ArticlesOrder+" 5o  !   �� *ArticleOrderSelected+y�5r  !   �� $ IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [  5s  "   �� 5t  &   %:   &	       &	        5u  *   6A   �� 5v  *   6G   5w  '   ��5y  "   �� 5z  &   "#  6,   .�5{  *   �� $ � ��% 6G   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=��� 5|  *   $ � ��$% 0,0,0,0q�6C   �� 5}  *   $ � ��$% 0q�6L   5~  '   & 5�  "   �� 5�  &   "#  6,   .�5�  *   �� $ � ��$% 80��6C   �� 5�  *   $ � ��
% �����6H   �� 5�  *   $ � ��$% 0q�6L   �� 5�  *   $ � ��$% 0,0,0,50q�6C   �� 5�  *   $ � ��% �#7F0E066G   �� 5�  *   $ � ��$% Bottom=�6U   �� 5�  *   $ � ��$% DemiBold"�6G   ' 5�  *   ��%  '��       '��     �� 5�  .   "# ��64   .�5�  2   �� $ � ��
% �   �6O   �� 5�  2   $ � ��$% 0,0,0,1q�6T   �� 5�  2   $ � ��
% �   �6P   �� 5�  2   $ � ��$% 5q�6L   �� 5�  2   $ � ��$% 0,10,0,0q�6K   �� 5�  2   $ � ��$% Normal"�6O   5�  /   �� 5�  .   "# ��64   .�5�  2   �� $ � ��
% �   �6O   �� 5�  2   $ �@��Padding$% 5q�6L   �� 5�  2   $ � ��$% 0,10,0,0q�6K   �� 5�  2   $ � ��$	% Top=�6V   �� 5�  2   $ � ��$% Normal"�6O   5�  /   5�  +   5�  '   ( 5�  "   �� 5�  &   "#  6,   .�5�  *   �� $ � ��$
% Auto��6C   �� 5�  *   $ � ��% 6G   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=��� 5�  *   $ � ��$% 0,0,0,0q�6C   �� 5�  *   $ � ��$% 0q�6L   5�  '   ) 5�  "     5�  &   $	* 26*
 5�  )   $+ Código Artículo��5�  )   $
, True��5�  )   - 5�  )   �� $ CodeArticle�. 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5�  6   $I txtCodeArticleSearch��6>   ��6\   �� $# DataContext.CodeArticleSearch�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  .��6  .  (System.Windows.Interactivity.InteractionM   TriggersM 5�  :   /  )System.Windows.Interactivity.EventTrigger  5�  >   N   	EventName$N KeyUp��6M   .  (System.Windows.Interactivity.TriggerBaseO   Actions.O 5�  B   /  )GalaSoft.MvvmLight.Command.EventToCommand  P   CommandP 6U   �� $+ %DataContext.KeyDownFindArticleCommand�0 �� *FindAncestor+";  5�  ?   .��5�  R   5�  7   � 5�  6   $
��Auto��5�  9   $
��Auto��5�  9   $��1q�5�  9   $��Bottom=�5�  9   ��5�  9   �� $&  DataContext.IsOpenPopCodeArticle�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  Q � PlacementTargetQ 5�  9   �� R �� ElementName$R txtCodeArticleSearch��.��5�  :   �� 
�������
���   �._�5�  >   �� $��Center=�6I   $/ Vertical=�6d   .+�5�  B     $
��Auto��5�  E   $ False��5�  E   $ False��5�  E   $ False��5�  E   $ False��5�  E   $
 True��5�  E   $  Single=�5�  E   $! FullRow=�5�  E   ��5�  E   �� $ DataContext.FindArticles�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  " 5�  E   �� $ DataContext.FindArticle�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  ) 5�  F     5�  J   $
* Auto
 5�  M   $+ Código��5�  M   $
, True��5�  M   - 5�  M   �� $ CodeArticle�5�  M     5�  J   $
* Auto
 5�  M   $+ Nombre��5�  M   $
, True��5�  M   - 5�  M   �� $ NameArticle�5�  M   5�  C   5�  ?   5�  ;   5�  7   5�  3   5�  /   2 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��$% Center=�6V   5�  /   5�  '     5�  &   $	* 40*
 5�  )   $+ Nombre��5�  )   $
, True��5�  )   - 5�  )   �� $ NameArticle�. 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5�  6   $I txtNameArticleSearch��6>   ��6\   �� $# DataContext.NameArticleSearch�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  .��6  M 5�  :     5�  >   $N KeyUp��6M   .O 5�  B     P 6U   �� $+ %DataContext.KeyDownFindArticleCommand�0 �� *FindAncestor+";  5�  ?   .��5�  R   5�  7   � 5�  6   $
��Auto��5�  9   $
��Auto��5�  9   $��1q�5�  9   $��Bottom=�5�  9   ��5�  9   �� $&  DataContext.IsOpenPopNameArticle�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  Q 5   9   �� $R txtNameArticleSearch��.��5  :   �� 
�������._�5  >   �� $��Center=�5  A   $��Center=�5  A   $/ Vertical=�5  A   .+�5  B     $
��Auto��5  E   $ False��5  E   $ False��5	  E   $ False��5
  E   $ False��5  E   $
 True��5  E   $  Single=�5  E   $! FullRow=�5  E   ��5  E   �� $ DataContext.FindArticles�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  " 5  E   �� $ DataContext.FindArticle�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  ) 5  F     5  J   $
* Auto
 5  M   $+ Código��5  M   $
, True��5  M   - 5  M   �� $ CodeArticle�5  M     5  J   $
* Auto
 5  M   $+ Nombre��5  M   $
, True��5  M   - 5  M   �� $ NameArticle�5  M   5   C   5!  ?   5"  ;   5#  7   5$  3   5%  /   2 5'  *   �� 5(  .   "# ��64   .�5)  2   �� $ � ��$% Center=�6V   5*  /   5,  '     5-  &   $	* 25*
 6=   $+ Cantidad��6I   3 5.  *   �� 5/  .   .R�50  2   �� $��Center=�6=   .+�51  6   �� -   5        $4 Right=�55  9   ��54  9   �� $ Quantity�$ {0:n2}��$ TwoWay=�$ PropertyChanged=�#
 [ 55  9   56  3   57  /   . 5:  *   �� 5;  .   .R�5<  2   �� $/ Vertical=�6=   .+�5=  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5>  6   -   5        $��70��5?  9   $4 Right=�5C  9   ��5B  9   �� $' !DataContext.QuantityArticleSearch�$ {0:n2}��0 �� *FindAncestor+";  5C  9   5D  3   5E  /   5G  '     5I  &   $	* 25*
 5J  )   $
5 Name��5K  )   $+ Estado��5L  )   $6 StateArticleId��5N  )   7 5M  )   �� $ StateArticleId�$ TwoWay=�8 5O  )   �� * DataContext.IsNotPurchaseOrder+#9 [ #
 [ . 5P  *   �� 5Q  .   .R�5R  2   �� $/ Vertical=�6=   .+�5S  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5T  6   $ cbStateArticle��5U  9   $	��200��5V  9   $
 Name��5W  9   $ StateArticleId��5Z  9     ComboBoxStyleGrid#��[ 5[  9   ��5X  9   �� $ DataContext.StatesArticle�$ TwoWay=�0 �� *FindAncestor+";   5Y  9   �� $&  DataContext.StateArticleIdSearch�$ TwoWay=�0 �� *FindAncestor+";  $ PropertyChanged=�5[  9   5\  3   5]  /   : 5_  *   �� 5`  .   "# ��64   .�5a  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+";  $ DataContext.StatesArticle��� 5b  2   $ � ��$% Center=�6V   5c  /   < 5e  *   �� 5f  .   "# ��64   .�5g  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+";  $ DataContext.StatesArticle�5h  /   5j  '     5k  &   $	* 25*
 5l  )   $5 PackageName��5m  )   $+ Empaque��5n  )   $6 	PackageId��5p  )   7 5o  )   �� $ 	PackageId�$ TwoWay=�8 5q  )   �� * DataContext.IsNotPurchaseOrder+#9 [ #
 [ . 5r  *   �� 5s  .   .R�5t  2   �� $/ Vertical=�6=   .+�5u  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5w  6   $ 
cbPackages��5x  9   $	��200��5y  9   S �� SelectedIndex$S 0��5z  9   $ 	PackageId��5|  9   #��[ 5}  9    5{  9   �� $! DataContext.PackageIdSearch�$ TwoWay=�0 �� *FindAncestor+";  ��5~  :   -  'System.Windows.Data.CompositeCollection  5  >   �� 5�  B   T ��Name$T StateArticleId��5�  E   $��Seleccione...��5�  E   U �� 
IsSelected$
U True��5�  E   $y�	Collapsed=�5�  E   �� 5�  B   V �� 
CollectionV 6V   �� #9 [ 5�  ?   ��5�  :   �� 5�  >   .R�5�  B   �� .+�5�  F   �� ��6P   �� $ PackageName�5�  C   5�  ?   5�  7   5�  3   5�  /   : 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+";  $ DataContext.Packages��� 5�  2   $ � ��$% Center=�6V   5�  /   < 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+";  $ DataContext.Packages�5�  /   5�  '     5�  &   $	* 25*
 5�  )   $+ Unidad de Medida��5�  )   $
, True��5�  )   - 5�  )   �� $ UnitMeasure�. 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5�  6   $��Center=�5�  9   $��Center=�5�  9   ��5�  9   �� $* $DataContext.UnitMeasureArticleSearch�0 �� *FindAncestor+";  5�  3   5�  /   2 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��$% Center=�6V   5�  /   5�  '     5�  &   $	* 25*
 5�  )   $+ Pedido Sugerido��5�  )   $
, True��5�  )   - 5�  )   �� $ SuggestedOrder�#
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5�  6   ��6>   �� $- 'DataContext.SuggestedOrderArticleSearch�0 �� *FindAncestor+";  #
 [ 5�  3   5�  /   2 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��$% Center=�6V   �� 5�  2   $ � ��$% Right=�6X   5�  /   5�  '     5�  &   $	* 25*
 5�  )   $+ Stock��5�  )   $
, True��5�  )   - 5�  )   �� $ Stock�#
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5�  6   ��6>   �� $$ DataContext.StockArticleSearch�0 �� *FindAncestor+";  #
 [ 5�  3   5�  /   2 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��$% Center=�6V   �� 5�  2   $ � ��$% Right=�6X   5�  /   5�  '     5�  &   $	* 25*
 5�  )   $+ Mínimo��5�  )   $
, True��5�  )   - 5�  )   �� $ Minimum�#
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5�  6   ��6>   �� $&  DataContext.MinimumArticleSearch�0 �� *FindAncestor+";  #
 [ 5�  3   5�  /   2 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��$% Center=�6V   �� 5�  2   $ � ��$% Right=�6X   5�  /   5�  '     5�  &   $	* 25*
 5�  )   $+ Máximo��5�  )   $
, True��5�  )   - 5�  )   �� $ Maximum�#
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5�  6   ��6>   �� $&  DataContext.MaximumArticleSearch�0 �� *FindAncestor+";  #
 [ 5   3   5  /   2 5  *   �� 5  .   "# ��64   .�5  2   �� $ � ��$% Center=�6V   �� 5  2   $ � ��$% Right=�6X   5  /   5	  '     5
  &   $	* 30*
 6=   $+ Observaciones��6I   . 5  *   �� 5  .   .R�5  2   �� $/ Vertical=�6=   .+�5  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   � 5  6   $��41��5  9   $��60��5  9   $��41��5  9   $
��Left=�5  9   = 5  9   �� $ DataContext.Observation�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  .+�5  :   �� $
��Wrap=�6�   ��6D   �� $ DataContext.Observation�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  ��5  >   �� 5  B   "# ��6H   .�5  F   �� $ � ��$
% Wrap=�6e   �� 5  F   $ � ��$% 11(�6a   �� 5  F   $ � ��% �#0006c   5  C   = 5  >   _� 5  B   #��[ 6�    6J   �� 0 �� *Self+$ PlacementTarget.Parent�.��5   F   �� ��6P   �� $ ToolTip���5!  J   �� 5"  N   "# ��6T   .�5#  R   �� $ � ��$
% Wrap=�6q   �� 5$  R   $ � ��$
% Auto��6k   �� 5%  R   $ � ��$% 15(�6m   5&  O   5(  G   5)  C   5,  ;   5-  7   �� 5.  6   $��20��5/  9   $��20��50  9   $��-10,-20,-10,0q�51  9   $��0q�52  9   $��Right=�53  9   ���#FF9800���#FF9800��56  9   �� $( "DataContext.CmdOpenEditObservation�0 �� *FindAncestor+";  .��57  :     $��Center=�6R   $
 Edit=�6o   58  7   � 59  6   $> 	InfoPopup��5:  9   $
? True��5;  9   $��Bottom=�5=  9   $@ False��5>  9   ��5<  9   �� $&  DataContext.IsPopObservationOpen�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  .��5?  :   �� $A InfoPopupBorder��5@  =   $	��200��5A  =   $	��100��5B  =   $B 10��5C  =   
�������
�������$��1q�5F  =   $C 5��5G  =   D 5H  >     5I  B   $E 10Q�5J  E   $	F 270Q�5K  E   $	G 0.5Q�5L  E   $H 7Q�5M  E   ._�5O  >   �� $I TextAreaPopup��5P  A   $
J True��5Q  A   
�������W �� 	MaxLength$	W 100��5S  A   $
K Wrap=�5U  A   $L Visible=�5V  A   ��5T  A   �� $ DataContext.Observation�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+";  5V  A   5W  ;   5X  7   5Z  3   5[  /   3 5]  *   �� 5^  .   .R�5_  2   �� .+�5`  6   � $��41��5a  9   $��60��5b  9   $��41��5c  9   $
��Left=�5d  9   = 5e  9   �� *Observations+$ TwoWay=�$ PropertyChanged=�.+�5f  :   �� $
��Wrap=�6�   ��6D   �� *Observations+$ TwoWay=�$ PropertyChanged=���5g  >   �� 5h  B   "# ��6H   .�5i  F   �� $ � ��$
% Wrap=�6e   �� 5j  F   $ � ��$% 11(�6a   �� 5k  F   $ � ��% �#0006c   5l  C   = 5n  >   _� 5o  B   #��[ 6�    6J   �� 0 �� *Self+$ PlacementTarget.Parent�.��5p  F   �� ��6P   �� $ ToolTip���5q  J   �� 5r  N   "# ��6T   .�5s  R   �� $ � ��$
% Wrap=�6q   �� 5t  R   $ � ��$
% Auto��6k   �� 5u  R   $ � ��$% 15(�6m   5v  O   5x  G   5y  C   5|  ;   5}  7   �� 5~  6   $��20��5  9   $��20��5�  9   $��-10,-20,-10,0q�5�  9   $��0q�5�  9   $��Right=�5�  9   ���#FF9800���#FF9800��5�  9   �� $, &DataContext.CmdOpenEditObservationItem�0 �� *FindAncestor+";  ��5�  9   �� $ .�.��5�  :     $��Center=�6R   $
 Edit=�6o   5�  7   � 5�  6   $> 	InfoPopup��5�  9   $
? True��5�  9   $��Bottom=�5�  9   $@ False��5�  9   ��5�  9   �� *IsPopObservationOpen+$ TwoWay=�$ PropertyChanged=�.��5�  :   �� $A InfoPopupBorder��5�  =   $	��200��5�  =   $	��100��5�  =   $B 10��5�  =   
�������
�������$��1q�5�  =   $C 5��5�  =   D 5�  >     5�  B   $E 10Q�5�  E   $	F 270Q�5�  E   $	G 0.5Q�5�  E   $H 7Q�5�  E   ._�5�  >   �� $I TextAreaPopup��5�  A   $
J True��5�  A   
�������$
K Wrap=�5�  A   $L Visible=�5�  A   ��5�  A   �� *Observations+$ TwoWay=�$ PropertyChanged=�5�  A   5�  ;   5�  7   5�  3   5�  /   5�  '     5�  &   $	* 25*
 6=   8 6I   �� *DataContext.IsCraftOrder+#9 [ #
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $��20,0,0,5q�5�  9   $��Agregar��5�  9   $
��Wrap=�5�  9   y�5�  9   �� $ DataContext.IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 0 �� *FindAncestor+";  �� 5�  6   $��30��5�  9   $��30��5�  9   $��25,0,5,0q�5�  9   $��0q�5�  9   $��Center=�5�  9   $��Center=�5�  9   ���#4CAF50���#4ACF50$��13q�5�  9   ��5�  9   �� $, &DataContext.ValidateFindArticleCommand�0 �� *FindAncestor+";  y�5�  9   �� $ DataContext.IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 0 �� *FindAncestor+";  .��5�  :     $��Center=�6R   $	 Add=�6o   5�  7   5�  3   5�  /   3 5�  *   �� 5�  .   .R�5�  2   �� $��Center=�5�  5   $��Center=�5�  5   $/ 
Horizontal=�5�  5   .+�5�  6   �� $��30��5�  9   $��30��5�  9   $��5,0,5,0q�5�  9   $��0q�5�  9   $��Center=�5�  9   $��Center=�5�  9   
���  ��
���  ��$��13q�5�  9   ��5�  9   �� $+ %DataContext.DeleteArticleOrderCommand�0 �� *FindAncestor+";  y�5�  9   �� $ DataContext.IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 0 �� *FindAncestor+";  .��5�  :     $��Center=�6R   $ Trash=�6o   5�  7   5�  3   5�  /   5�  '   5�     5�     �� 5�     $
��0,20q�5�     $��Right=�5�     $��Bottom=�5�     $/ 
Horizontal=�5�     .+�5�     �� -	   5        X ��Name$X btnCleanPage��5�  !   $��0,0,5,0q�5�  !   
���  ��
���  ��$��Limpiar solicitud��5�  !   ��5�  !   �� *DeleteArticlesOrderCommand+{�5�  !   �� *EnableCleanOrder+y�5�  !   �� $ IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ �� 5�     -
   5        $X btnSelectArticles��5�  !   $��0,0,5,0q�5�  !   ���#00BCD4���#00BCD4$��Agregar Artículos(F3)��5�  !   ��5�  !   �� *ShowModalArticlesCommand+y�5�  !   �� $ IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ �� 5�     -   5        $X btnSave��5�  !   $��0,0,5,0q�5�  !   ���#FF9800���#FF9800$��Guardar Borrador��5  !   ��5  !   �� *!ValidateOpenConfirmationCommand+{�5  !   �� *EnableSavedAndSendOrder+y�5  !   �� $ IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ �� 5     -   5        $X btnSend��5  !   $��0,0,5,0q�5  !   ���#4ACF50���#4ACF50$��Actualizar Documento��5  !   ��5
  !   �� *)'ValidateErasedConfirmationUpdateCommand+{�5  !   �� *EnableSavedAndSendOrder+y�5  !   �� $ IsNotCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ �� 5     -   5        $X btnEdit��5  !   $��0,0,5,0q�5  !   ���#4ACF50���#4ACF50$��Generar Documento��5  !   ��5  !   �� *#!ValidateErasedConfirmationCommand+{�5  !   �� *EnableSavedAndSendOrder+y�5  !   �� $ IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 5     5     5     5     � 5       IconCard#��[ 6   D 5       5     $E 20Q�5      Y   RenderingBias$Y Quality=�5!     $H 1Q�5"     Z   Color$Z 	#FFECECEC��5#     .+�5%     ��   
BorderCard#��[ 6     5&     $��30��5'     $��30��5(     $��5q�5)     $��10q�5*     $��Center=�5+     $��Center=�5,     
�������$ PlaylistAddCheck=�5.     5/     � 51      	 Title#��[ 6   .+�53     ��   ContentTitle#��[ 6   .+�54     ��   	TextTitle#��[ 6    ��6C   �� *OrderType.OrderTypeName+$% Solicitud de Pedido - Tipo: {0}��55     57     58     5;     5=     