   M S B A M L   `   `   `  ����e  aPresentationFramework.AeroLite, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35kNclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroLiteMicrosoft.Windows.Themes  5      A =EVO_PV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EVO_PV.UtilitiesEVO_PV.Utilities 5	      !   EVO_PV.Views.UCOrderRequest   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      aThemesNclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroLite     5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      *localclr-namespace:EVO_PV.Utilities  5	      Llocal19http://schemas.microsoft.com/winfx/2006/xaml/presentation     5
      U	 QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5      -   5          >�Name$  UserControl��5      $
|�True��5       � 	Resources 5       �� MergedDictionaries �� Source   	Factories �� Source �� Path �� Mode �� UpdateSourceTrigger  FactorieTypes  StatesArticle  Packages  VisibilityConverterBool�� 5   
    5      �� 5      $< 6/EVO_PV;Component/Resources/Dictionaries/DictTags.xaml?�6%   �� 5      $2 ,/EVO_PV;Component/Resources/Style/style.xaml?�6%   %�  &	        &	 O     &	 �     &	 �     &	 C    �� 5       65   �� $ 	Factories�$ TwoWay=�$ PropertyChanged=��� 5       69   �� $ FactorieTypes�$ TwoWay=�$ PropertyChanged=��� 5       69   �� $ StatesArticle�$ TwoWay=�$ PropertyChanged=��� 5       64   �� $ Packages�$ TwoWay=�$ PropertyChanged=��� 5      6+   5      .��5"      � $
��Auto��6   ���#eee � ColumnDefinitions 5$   
   �� 5%      $��* �6   	 � RowDefinitions	 5(   
   �� 5)      .+�5+   
   �� $��0��5,      $	��150��5-      $��0,0,40,0q�5.      $��0q�5/      $��Right=�50      $	��Top=�51      ���#00BCD4���#00BCD4 " MaterialDesignRaisedDarkButton#��[ 55      ��54      �� $ ViewDetailsCraft�.��56      � $	��150��6   $��Center=�6   .+�57      ' 	 !MaterialDesignThemes.Wpf.PackIcon  $��10,2,0,0q�58      ���#FFFFFF
   Kind$
 ChevronLeft=�5:      �� 5;      $��Center=�6   $��REGRESAR��69   5<      5=      � 5?   
   $��0��5@      $
��Auto��5A      $��0,40,0,0q�5B      .+�5D      # 	 MaterialDesignThemes.Wpf.Card  $��1��6"   $��
30,0,30,10q�6/   .��5F      � $
��Auto��6     ContentCard#��[ 6$   .+�5H      �� $
��Auto��6!   .+�5J      �� .+�5L      � $��	0,10,0,20q�6#    5N   "   �� 5O   &   $��1* �67   �� 5P   &   $��1* �67   �� 5Q   &   $��1* �67   �� 5R   &   $��1* �67   	 5U   "   �� 5V   &   .+�5Y   "   �� $��0��5Z   %   $��0��5[   %     
HeaderView#��[ 5\   %   .+�5^   &   ��   TextHeaderView#��[ 60    	 lblDateRequest#��� 	 6X   �� 5`   &    
 DateCreation#��[
 60   ��6V   �� $ PropertyChanged=� �� StringFormat$ 
dd/MM/yyyy��$ 	DateOrder� �� ValidatesOnDataErrors$
 True�� �� NotifyOnValidationError$
 True��$ OneWay=�5b   #   �� 5d   "   $��0��5e   %   $��1��5f   %   #��[ 5g   %   .+�5i   &   �� #��[ 60     lblDateDelivery#���  6X   (  "System.Windows.Controls.DatePicker  5k   &   -   5        $��dpDateDelivery��5l   )   $	��110��5m   )   $��
10,-4,-1,0q�5n   )   $��Bottom=�5o   )   ���	#FFECECEC$|�False��5q   )      IsTodayHighlighted$ False��5s   )    � Language$ ES-mx�5t   )      IsDropDownOpen 5r   )   �� $
 Open�   SelectedDate 5v   )   �� $ DateDelivery�$ TwoWay=�$
 True��$
 True��$ 	LostFocus=� 5w   *     PrimaryHueMidBrush �� Color  MaterialDesignBody��%T   &	       &	 !     �� 5x   .   $ #FF9800��6Y   �� 5y   .   $ Black��6Y   5z   +   5{   '   5}   #   �� 5~   "   $��0��5   %   $��2��5�   %   $��2��5�   %   #��[ 5�   %   y�5�   %   �� $ IsPurchaseOrder�$ TwoWay=�$ PropertyChanged=� �� 	Converter# [ .+�5�   &   �� #��[ 60     lblRequestFor#���  6X   �� 5�   &   #��[
 60   $��Área de Compras��6V   5�   #   �� 5�   "   $��0��5�   %   $��2��5�   %   $��2��5�   %   #��[ 5�   %   y�5�   %   �� $ IsNotPurchaseOrder�$ TwoWay=�$ PropertyChanged=�# [ .+�5�   &   �� #��[ 60   #���  6X   �� 5�   &   -   5         ��Name$ 	cbPlantas��5�   )    �� SelectedIndex$ 0��5�   )    �� SelectedValuePath$ WhsTypeName��5�   )     ComboBoxStyle#��[ 5�   )    �� SelectedValue 5�   )   �� $ FactoryTypeSelectedName�$ TwoWay=�$ PropertyChanged=���5�   *   -  'System.Windows.Data.CompositeCollection  5�   .   �� 5�   2   -   5         ��Name$ WhsTypeName��5�   5   $��Seleccione...��5�   5    �� 
IsSelected$
 True��5�   5   $y�	Collapsed=�5�   5   �� 5�   2    �� 
Collection 6F   ��  �� Source# [ 5�   /   ��5�   *   �� 5�   .   .R�5�   2   �� .+�5�   6   �� ��6@   �� $ WhsTypeName�5�   3   5�   /   5�   '   �� 5�   &   -   5        $ cbPlantasSelecionada��5�   )   $ 0��5�   )   $ WhsCode��5�   )   #��[ 5�   )    �� Text$ Seleccione...��5�   )   {�5�   )   �� $ IsNotFactory�$ TwoWay=�$ PropertyChanged=� 5�   )   �� $ FactoryCode�$ TwoWay=�$ PropertyChanged=���5�   *     5�   .   �� 5�   2   -   5        $ Codigo��5�   5   $��Seleccione...��5�   5   $
 True��5�   5   $y�	Collapsed=�5�   5   �� 5�   2    6F   �� # [  5�   /   ��5�   *   �� 5�   .   .R�5�   2   �� .+�5�   6   �� ��6@   �� $ WhsName�5�   3   5�   /   5�   '   5�   #   5�      5�      �� 5�      $
��Auto��5�      $��Right=�5�      $��Bottom=�5�       �� Orientation$ 
Horizontal=�5�       5�         BooleanToVisibilityConverter  ProxyElement � DataContext��%C   &	       &	      �� 5�   "   6F   � 5�   "    6H   �� 5�      .+�5�      �� #��[ 6-   $y�	Collapsed=�6U   &   System.Windows.Controls.DataGrid  5�      -   5          Name$ dgOrderArticles��5�   !   $��2��5�   !   $��3��5�   !   $
��1020��5�   !       AutoGenerateColumns$  False��5�   !   
�������!   CanUserAddRows$! False��5�   !   "   CanUserDeleteRows$
" True��5�   !   #   CanUserReorderColumns$# False��5�   !   $   CanUserResizeColumns$$ False��5�   !     SuojiHeaderStyle%   ColumnHeaderStyle#% [ 5�   !   &   SelectionMode$& Single=�5�   !   '   SelectionUnit$' FullRow=�5�   !   ��5�   !   �� *ArticlesOrder+( �� SelectedItem( 5�   !   �� *ArticleOrderSelected+ 5�   "   '  !EVO_PV.Utilities.DecimalConverter  decimalConverter�� 5�   &   %   &	         5�   *   6A   5�   '   ��5�   "   �� 5�   &   ) �� 
TargetType)  #System.Windows.Controls.DataGridRow")  6,   .�5�   *   �� * �� Property* � ��+ �� Value+ 6G   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=��� 5�   *   * � ��$+ 0,0,0,0q�6C   �� 5�   *   * � ��$+ 0q�6L   5�   '   ,   RowStyle, 5�   "   �� 5�   &   ")  6,   .�5�   *   �� * � ��$
+ Auto��6C   5�   '   -   Columns- 5�   "   0  *System.Windows.Controls.DataGridTextColumn  5�   &   ,	  &System.Windows.Controls.DataGridColumn. 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	. 20*
 5�   )   / 	  Header$/ Código Artículo��5�   )   0 	  
IsReadOnly$
0 True��5�   )   1  +System.Windows.Controls.DataGridBoundColumn1   Binding1 5�   )   �� $ CodeArticle�2 	  HeaderTemplate2 5�   *   �� 5�   .   .R�5  2   �� $ Vertical=�6=   .+�5  6   �� $
��Wrap=�6�   ��6@   �� *	Content+3 �� RelativeSource3 �� 4 �� Mode$4 TemplatedParent=�6�   �� 5  6   5 ��Name$5 txtCodeArticleSearch��6>   ��6\   �� $# DataContext.CodeArticleSearch�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+6 �� AncestorType"6  .��6  .  (System.Windows.Interactivity.Interaction7   Triggers7 5  :   /  )System.Windows.Interactivity.EventTrigger  5  >   8   	EventName$8 KeyDown��6M   .  (System.Windows.Interactivity.TriggerBase9   Actions.9 5	  B   /  )GalaSoft.MvvmLight.Command.EventToCommand  :   Command: 6U   �� $/ )DataContext.KeyDownFindCodeArticleCommand�3 �� *FindAncestor+"6  5
  ?   .��5  R   5  7   � 5  6   $
��Auto��5  9   $
��Auto��5  9   $��1q�5  9   $��Bottom=�5  9   ; � 	StaysOpen$; False��5  9   ��5  9   �� $&  DataContext.IsOpenPopCodeArticle�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+"6  < � PlacementTarget< 5  9   �� = �� ElementName$= txtCodeArticleSearch��.��5  :   �� 
�������
���   �$��0q�5  =   ._�5  >   �� $��Center=�5  A   $��Center=�5  A   $ Vertical=�5   A   .+�5"  B     $
��Auto��5#  E   $  False��5$  E   $! False��5%  E   $" False��5&  E   $# False��5'  E   $
$ True��5(  E   $& Single=�5+  E   $' FullRow=�5,  E   ��5)  E   �� $ DataContext.FindArticles�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+"6  ( 5*  E   �� $ DataContext.FindArticle�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+"6  - 5.  F     50  J   $
. Auto
 51  M   $/ Código��53  M   $
0 True��54  M   1 52  M   �� $ CodeArticle�54  M     56  J   $
. Auto
 57  M   $/ Nombre��59  M   $
0 True��5:  M   1 58  M   �� $ NameArticle�5:  M   5>  C   5@  ?   5B  ;   5D  7   5F  3   5H  /   >   ElementStyle> 5L  *   �� 5M  .   ") ��64   .�5N  2   �� * � ��$+ Center=�6V   5O  /   5Q  '     5S  &   $	. 21*
 5T  )   $/ Nombre��5V  )   $
0 True��5W  )   1 5U  )   �� $ NameArticle�2 5Y  *   �� 5[  .   .R�5\  2   �� $ Vertical=�6=   .+�5]  6   �� $
��Wrap=�6�   ��6@   �� *	Content+3 �� $4 TemplatedParent=�6�   �� 5^  6   $5 txtNameArticleSearch��5_  9   $	��100��5`  9   ��5a  9   �� $# DataContext.NameArticleSearch�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+"6  .��6�   7 5c  :     5d  >   $8 KeyDown��6M   .9 5e  B     : 6U   �� $/ )DataContext.KeyDownFindNameArticleCommand�3 �� *FindAncestor+"6  5f  ?   .��5g  R   5h  7   � 5i  6   $
��Auto��5j  9   $
��Auto��5k  9   $��1q�5l  9   $��Bottom=�5n  9   $; False��5p  9   ��5m  9   �� $&  DataContext.IsOpenPopNameArticle�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+"6  < 5o  9   �� $= txtNameArticleSearch��.��5q  :   �� 
�������._�5r  >   �� $��Center=�5s  A   $��Center=�5t  A   $ Vertical=�5u  A   .+�5w  B     $
��Auto��5x  E   $  False��5y  E   $! False��5z  E   $" False��5{  E   $# False��5|  E   $
$ True��5}  E   $& Single=�5�  E   $' FullRow=�5�  E   ��5~  E   �� $ DataContext.FindArticles�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+"6  ( 5  E   �� $ DataContext.FindArticle�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+"6  - 5�  F     5�  J   $
. Auto
 5�  M   $/ Código��5�  M   $
0 True��5�  M   1 5�  M   �� $ CodeArticle�5�  M     5�  J   $
. Auto
 5�  M   $/ Nombre��5�  M   $
0 True��5�  M   1 5�  M   �� $ NameArticle�5�  M   5�  C   5�  ?   5�  ;   5�  7   5�  3   5�  /   > 5�  *   �� 5�  .   ") ��64   .�5�  2   �� * � ��$+ Center=�6V   5�  /   5�  '   4  .System.Windows.Controls.DataGridTemplateColumn  5�  &   $	. 25*
 5�  )   $/ Cantidad��5�  )   ? 	  SortMemberPath$? Quantity��5�  )   2 5�  *   �� 5�  .   .R�5�  2   �� $ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+3 �� $4 TemplatedParent=�6�   �� 5�  6   -   5        $��60��5�  9   @ �� TextAlignment$@ Right=�5�  9   ��5�  9   �� $' !DataContext.QuantityArticleSearch�$ C��3 �� *FindAncestor+"6  # [ 5�  9   5�  3   5�  /   A   CellTemplateA 5�  *   �� 5�  .   .R�5�  2   � $��Center=�67   B +� FocusedElementB 6R   �� $= Quantity��.+�5�  6   �� $5 Quantity��5�  9   -	   5        $��Center=�5�  9   $
|�True��5�  9   $@ Right=�5�  9   ��5�  9   �� *
Quantity+$ TwoWay=�$ PropertyChanged=�# [ 5�  9   5�  3   5�  /   5�  '   4  .System.Windows.Controls.DataGridComboBoxColumn  5�  &   $	. 25*
 5�  )   C   DisplayMemberPath$
C Name��5�  )   $/ Estado��5�  )   D   SelectedValuePath$D StateArticleId��5�  )   E   SelectedValueBindingE 5�  )   �� $ StateArticleId�$ TwoWay=�F 	  
VisibilityF 5�  )   �� * DataContext.IsNotPurchaseOrder+# [ # [ 2 5�  *   �� 5�  .   .R�5�  2   �� $ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+3 �� $4 TemplatedParent=�6�   �� 5�  6   $ cbStateArticle��5�  9   $	��200��5�  9   $ 0��5�  9   $ StateArticleId��5�  9     ComboBoxStyleGrid#��[ 5�  9    5�  9   �� $&  DataContext.StateArticleIdSearch�$ TwoWay=�3 �� *FindAncestor+"6  ��5�  :     5�  >   �� 5�  B    6V   �� # [ 5�  ?   ��5�  :   �� 5�  >   .R�5�  B   �� .+�5�  F   �� ��6P   �� $
 Name�5�  C   5�  ?   5�  7   5�  3   5�  /   G   ElementStyleG 5�  *   �� 5�  .   ") ��64   .�5�  2   �� * � ��+ 6P   �� 3 �� *FindAncestor+"6  $ DataContext.StatesArticle��� 5�  2   * � ��$+ Center=�6V   5�  /   H   EditingElementStyleH 5�  *   �� 5�  .   ") ��64   .�5�  2   �� * � ��+ 6P   �� 3 �� *FindAncestor+"6  $ DataContext.StatesArticle�5�  /   5�  '     5�  &   $	. 25*
 5�  )   $C PackageName��5�  )   $/ Empaque��5�  )   $D 	PackageId��5�  )   E 5�  )   �� $ 	PackageId�$ TwoWay=�$ PropertyChanged=�F 5�  )   �� * DataContext.IsNotPurchaseOrder+# [ # [ 2 5�  *   �� 5�  .   .R�5�  2   �� $ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+3 �� $4 TemplatedParent=�6�   �� 5   6   $ 
cbPackages��5  9   $	��200��5  9   $ 0��5  9   $ 	PackageId��5  9   #��[ 5  9    5  9   �� $! DataContext.PackageIdSearch�$ TwoWay=�3 �� *FindAncestor+"6  ��5  :     5  >   �� 5	  B   $ StateArticleId��5
  E   $��Seleccione...��5  E   $
 True��5  E   $y�	Collapsed=�5  E   �� 5  B    6V   �� # [ 5  ?   ��5  :   �� 5  >   .R�5  B   �� .+�5  F   �� ��6P   �� $ PackageName�5  C   5  ?   5  7   5  3   5  /   G 5  *   �� 5  .   ") ��64   .�5  2   �� * � ��+ 6P   �� 3 �� *FindAncestor+"6  $ DataContext.Packages��� 5  2   * � ��$+ Center=�6V   5   /   H 5"  *   �� 5#  .   ") ��64   .�5$  2   �� * � ��+ 6P   �� 3 �� *FindAncestor+"6  $ DataContext.Packages�5%  /   5'  '     5)  &   $	. 20*
 5*  )   $/ Unidad de Medida��5,  )   $
0 True��5-  )   1 5+  )   �� $ UnitMeasure�2 5.  *   �� 5/  .   .R�50  2   �� $ Vertical=�6=   .+�51  6   �� $
��Wrap=�6�   ��6@   �� *	Content+3 �� $4 TemplatedParent=�6�   �� 52  6   $��0,0,10,0q�6>   ��6P   �� $* $DataContext.UnitMeasureArticleSearch�3 �� *FindAncestor+"6  53  3   54  /   > 56  *   �� 57  .   ") ��64   .�58  2   �� * � ��$+ Center=�6V   59  /   5;  '     5=  &   $	. 25*
 5>  )   $/ Pedido Sugerido��5@  )   $
0 True��5A  )   $? SuggestedOrder��5B  )   1 5?  )   �� $ SuggestedOrder�# [ 2 5C  *   �� 5D  .   .R�5E  2   �� $ Vertical=�6=   .+�5F  6   �� $
��Wrap=�6�   ��6@   �� *	Content+3 �� $4 TemplatedParent=�6�   �� 5G  6   I �� 
IsReadOnly$
I True��6>   ��6P   �� $- 'DataContext.SuggestedOrderArticleSearch�3 �� *FindAncestor+"6  # [ 5H  3   5I  /   > 5K  *   �� 5L  .   ") ��64   .�5M  2   �� * � ��$+ Right=�6X   �� 5N  2   * � ��$+ Center=�6V   5O  /   5Q  '     5S  &   $	. 25*
 5T  )   $/ Stock��5V  )   $
0 True��5W  )   $? Stock��5X  )   1 5U  )   �� $ Stock�# [ 2 5Y  *   �� 5Z  .   .R�5[  2   �� $ Vertical=�6=   .+�5\  6   �� $
��Wrap=�6�   ��6@   �� *	Content+3 �� $4 TemplatedParent=�6�   �� 5]  6   $
I True��6>   ��6P   �� $$ DataContext.StockArticleSearch�3 �� *FindAncestor+"6  # [ 5^  3   5_  /   > 5a  *   �� 5b  .   ") ��64   .�5c  2   �� * � ��$+ Right=�6X   �� 5d  2   * � ��$+ Center=�6V   5e  /   5g  '     5i  &   $	. 21*
 5j  )   $/ Mínimo��5l  )   $
0 True��5m  )   1 5k  )   �� $ Minimum�# [ 2 5n  *   �� 5o  .   .R�5p  2   �� $ Vertical=�6=   .+�5q  6   �� $
��Wrap=�6�   ��6@   �� *	Content+3 �� $4 TemplatedParent=�6�   �� 5r  6   $
I True��6>   ��6P   �� $&  DataContext.MinimumArticleSearch�3 �� *FindAncestor+"6  # [ 5s  3   5t  /   > 5v  *   �� 5w  .   ") ��64   .�5x  2   �� * � ��$+ Right=�6X   �� 5y  2   * � ��$+ Center=�6V   5z  /   5|  '     5~  &   $	. 21*
 5  )   $/ Máximo��5�  )   $
0 True��5�  )   1 5�  )   �� $ Maximum�# [ 2 5�  *   �� 5�  .   .R�5�  2   �� $ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+3 �� $4 TemplatedParent=�6�   �� 5�  6   $
I True��6>   ��6P   �� $&  DataContext.MaximumArticleSearch�3 �� *FindAncestor+"6  # [ 5�  3   5�  /   > 5�  *   �� 5�  .   ") ��64   .�5�  2   �� * � ��$+ Right=�6X   �� 5�  2   * � ��$+ Center=�6V   5�  /   5�  '     5�  &   $	. 30*
 6=   $/ Observación��6I   2 5�  *   �� 5�  .   .R�5�  2   �� $ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+3 �� $4 TemplatedParent=�6�   � 5�  6   $��41��5�  9   $��60��5�  9   $��41��5�  9   $
��Left=�5�  9   J � ToolTipJ 5�  9   �� $ DataContext.Observation�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+"6  .+�5�  :   �� $
��Wrap=�6�   ��6D   �� $ DataContext.Observation�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+"6  ��5�  >   �� 5�  B   ") ��6H   .�5�  F   �� * � ��$
+ Wrap=�6e   �� 5�  F   * � ��$+ 11(�6a   �� 5�  F   * � ��+ �#0006c   5�  C   J 5�  >   _� 5�  B     CustomToolTip#��[ 6�    6J   �� 3 �� *Self+$ PlacementTarget.Parent�.��5�  F   �� ��6P   �� $ ToolTip���5�  J   �� 5�  N   ") ��6T   .�5�  R   �� * � ��$
+ Wrap=�6q   �� 5�  R   * � ��$
+ Auto��6k   �� 5�  R   * � ��$+ 15(�6m   5�  O   5�  G   5�  C   5�  ;   5�  7   �� 5�  6   $��20��5�  9   $��20��5�  9   $��-20,-20,-10,0q�5�  9   $��0q�5�  9   $��Right=�5�  9   ���#FF9800���#FF9800��5�  9   �� $( "DataContext.CmdOpenEditObservation�3 �� *FindAncestor+"6  .��5�  :     $��Center=�6R   $

 Edit=�6o   5�  7   � 5�  6   K �Name$K 	InfoPopup��5�  9   L � AllowsTransparency$
L True��5�  9   $��Bottom=�5�  9   $; False��5�  9   ��5�  9   �� $&  DataContext.IsPopObservationOpen�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+"6  .��5�  :   �� M ��Name$M InfoPopupBorder��5�  =   $	��200��5�  =   $	��100��5�  =   N K� ZIndex$N 10��5�  =   
�������
�������$��1q�5�  =   O �� CornerRadius$O 5��5�  =   P J� EffectP 5�  >   3  -System.Windows.Media.Effects.DropShadowEffect  5�  B   Q   
BlurRadius$Q 10Q�5�  E   R   	Direction$	R 270Q�5�  E   S   Opacity$	S 0.5Q�5�  E   T   ShadowDepth$T 7Q�5�  E   ._�5�  >   �� $5 TextAreaPopup��5�  A   U �� AcceptsReturn$
U True��5�  A   
�������V �� 	MaxLength$	V 100��5�  A   W �� TextWrapping$
W Wrap=�5�  A   "X �� VerticalScrollBarVisibility$X Visible=�5�  A   ��5�  A   �� $ DataContext.Observation�$ TwoWay=�$ PropertyChanged=�3 �� *FindAncestor+"6  5�  A   5�  ;   5�  7   5�  3   5�  /   A 5�  *   �� 5�  .   .R�5�  2   �� .+�5�  6   � $��41��5�  9   $��60��5�  9   $��41��5�  9   $
��Left=�5�  9   J 5�  9   �� *Observations+$ TwoWay=�$ PropertyChanged=�.+�5�  :   �� $
��Wrap=�6�   ��6D   �� *Observations+$ TwoWay=�$ PropertyChanged=���5�  >   �� 5�  B   ") ��6H   .�5�  F   �� * � ��$
+ Wrap=�6e   �� 5�  F   * � ��$+ 11(�6a   �� 5�  F   * � ��+ �#0006c   5�  C   J 5�  >   _� 5�  B   #��[ 6�    6J   �� 3 �� *Self+$ PlacementTarget.Parent�.��5�  F   �� ��6P   �� $ ToolTip���5   J   �� 5  N   ") ��6T   .�5  R   �� * � ��$
+ Wrap=�6q   �� 5  R   * � ��$
+ Auto��6k   �� 5  R   * � ��$+ 15(�6m   5  O   5  G   5  C   5  ;   5  7   �� 5  6   $��20��5  9   $��20��5  9   $��-10,-20,-10,0q�5  9   $��0q�5  9   $��Right=�5  9   ���#FF9800���#FF9800��5  9   �� $, &DataContext.CmdOpenEditObservationItem�3 �� *FindAncestor+"6  ��5  9   �� $ .�.��5  :     $��Center=�6R   $

 Edit=�6o   5  7   � 5  6   $K 	InfoPopup��5  9   $
L True��5  9   $��Bottom=�5  9   $; False��5  9   ��5  9   �� *IsPopObservationOpen+$ TwoWay=�$ PropertyChanged=�.��5  :   �� $M InfoPopupBorder��5   =   $	��200��5!  =   $	��100��5"  =   $N 10��5#  =   
�������
�������$��1q�5&  =   $O 5��5'  =   P 5(  >     5)  B   $Q 10Q�5*  E   $	R 270Q�5+  E   $	S 0.5Q�5,  E   $T 7Q�5-  E   ._�5/  >   �� $5 TextAreaPopup��50  A   $
U True��51  A   
�������$	V 100��53  A   $
W Wrap=�55  A   $X Visible=�56  A   ��54  A   �� *Observations+$ TwoWay=�$ PropertyChanged=�56  A   57  ;   58  7   59  3   5:  /   5<  '     5=  &   $	. 25*
 6=   2 5>  *   �� 5?  .   .R�5@  2   �� $��Center=�6=   $ Vertical=�6Z   .+�5A  6   �� $��
-10,0,0,10q�5B  9   $��Agregar��5C  9   Y �� TextAlignment$Y Center=�5D  9   $
��Wrap=�5E  9   �� 5F  6   $��30��5G  9   $��30��5H  9   $��5,0,5,0q�5I  9   $��0q�5J  9   $��Center=�5K  9   $��Center=�5L  9   ���#4CAF50���#4ACF50$��13q�5O  9   ��5P  9   �� $, &DataContext.ValidateFindArticleCommand�3 �� *FindAncestor+"6  .��5Q  :     $��Center=�6R   $	
 Add=�6o   5R  7   5S  3   5T  /   A 5V  *   �� 5W  .   .R�5X  2   �� $��30��5Y  5   $��30��5Z  5   $��5,0,5,0q�5[  5   $��0q�5\  5   $��Center=�5]  5   
���  ��
���  ��$��13q�5`  5   ��5a  5   �� $+ %DataContext.DeleteArticleOrderCommand�3 �� *FindAncestor+"6  .��5b  6     $��Center=�6N   $
 Trash=�6k   5c  3   5d  /   5f  '   5j     5l     �� 5n     $
��0,20q�5o     $��Right=�5p     $��Bottom=�5q     $ 
Horizontal=�5r     .+�5t     �� -
   5        Z ��Name$Z btnCleanPage��5u  !   $��0,0,5,0q�5v  !   
���  ��
���  ��$��Limpiar solicitud��5z  !   ��5y  !   �� *CleanFormCommand+{�5{  !   �� *EnableAddedItems+�� 5}     -   5        $Z btnSelectArticles��5~  !   $��0,0,5,0q�5  !   ���#00BCD4���#00BCD4$ ��Seleccionar Artículos(F3)��5�  !   ��5�  !   �� *ShowModalArticlesCommand+5�  !   �� 5�     -   5        $Z btnSave��5�  !   $��0,0,5,0q�5�  !   ���#FF9800���#FF9800$��Guardar Borrador��5�  !   ��5�  !   �� *!ValidateOpenConfirmationCommand+{�5�  !   �� *EnableSavedAndSendOrder+�� 5�     -   5        $Z btnSend��5�  !   $��0,0,5,0q�5�  !   ���#4ACF50���#4ACF50$��Generar Documento��5�  !   ��5�  !   �� *#!ValidateErasedConfirmationCommand+{�5�  !   �� *EnableSavedAndSendOrder+5�     5�     5�     5�     � 5�       IconCard#��[ 6   P 5�       5�     $Q 20Q�5�     [   RenderingBias$[ Quality=�5�     $T 1Q�5�     \   Color$\ 	#FFECECEC��5�     .+�5�     ��   
BorderCard#��[ 6     5�     $��30��5�     $��30��5�     $��5q�5�     $��10q�5�     $��Center=�5�     $��Center=�5�     
�������$
 PlaylistAddCheck=�5�     5�     � 5�      	 Title#��[ 6   .+�5�     ��   ContentTitle#��[ 6   .+�5�     ��   	TextTitle#��[ 6    ��6C   �� *OrderType.OrderTypeName+$% Solicitud de Pedido - Tipo: {0}��5�     5�     5�     5�     5�     