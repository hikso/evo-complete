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
       &	 !     �� 5�   .   $ #FF9800��6Y   �� 5�   .   $ Black��6Y   5�   +   5�   '   5�   #   �� 5�   "   $��0��5�   %   $��2��5�   %   #��[ 5�   %   .+�5�   &   �� #��[ 60     lblRequestFor#���  6X   �� 5�   &   -   5         ��Name$ 	cbPlantas��5�   )    �� DisplayMemberPath$ WhsName��5�   )   ${�False��5�   )    �� SelectedValuePath$ WhsCode��5�   )     ComboBoxStyle#��[ 5�   )   ��5�   )   �� $ 	Factories� �� SelectedValue 5�   )   �� $ FactoryCode�$ TwoWay=�$ PropertyChanged=�5�   )   5�   #   5�      5�      �� 5�       5�        ProxyElement � DataContext��%&   &	       � 5�   "    6H   �� 5�      .+�5�      �� #��[ 6-   $y�	Collapsed=�6U   &   System.Windows.Controls.DataGrid  5�      -   5          Name$ dgOrderArticles��5�   !   $��2��5�   !   $��4��5�   !   $
��1020��5�   !      AutoGenerateColumns$ False��5�   !      CanUserAddRows$ False��5�   !      CanUserDeleteRows$ False��5�   !      CanUserReorderColumns$ False��5�   !      CanUserResizeColumns$
 True��5�   !       SelectionMode$  Single=�5�   !   !   SelectionUnit$! FullRow=�5�   !   ��5�   !   �� *ArticlesOrder+" �� SelectedItem" 5�   !   �� *ArticleOrderSelected+ 5�   "   '   !EVO_PV.Utilities.DecimalConverter  decimalConverter�� 5�   &   %   &	         5�   *   6A   5�   '   ��5�   "   �� 5�   &   # �� 
TargetType)  #System.Windows.Controls.DataGridRow"#  6,   .�5�   *   �� $ �� Property$ � ��% �� Value% 6G   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=��� 5�   *   $ � ��$% 0,0,0,0q�6C   �� 5�   *   $ � ��$% 0q�6L   5�   '   &   ColumnHeaderStyle& 5�   "   �� 5�   &   =  7System.Windows.Controls.Primitives.DataGridColumnHeader"#  6,   .�5�   *   �� $ � ��$% 80��6C   �� 5�   *   $ � ��
% �����6H   �� 5�   *   $ � ��$% 0q�6L   �� 5�   *   $ � ��$% 0,0,0,50q�6C   �� 5�   *   $ � ��% �#7F0E066G   �� 5�   *   $ � ��$% Bottom=�6U   �� 5�   *   $ � ��$% DemiBold"�6G   ' �� 	Resources' 5�   *   ��%  '��       '��     �� 5�   .   "# ��64   .�5�   2   �� $ � ��
% �   �6O   �� 5�   2   $ � ��$% 0,0,0,1q�6T   �� 5�   2   $ � ��
% �   �6P   �� 5�   2   $ � ��$% 5q�6L   �� 5�   2   $ � ��$% 0,10,0,0q�6K   �� 5�   2   $ � ��$% Normal"�6O   5�   /   �� 5�   .   "# ��64   .�5�   2   �� $ � ��
% �   �6O   �� 5�   2   $ �@��Padding$% 5q�6L   �� 5�   2   $ � ��$% 0,10,0,0q�6K   �� 5�   2   $ � ��$	% Top=�6V   �� 5�   2   $ � ��$% Normal"�6O   5�   /   5�   +   5�   '   (   RowStyle( 5�   "   �� 5�   &   "#  6,   .�5�   *   �� $ � ��$
% Auto��6C   �� 5�   *   $ � ��% 6G   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=��� 5�   *   $ � ��$% 0,0,0,0q�6C   �� 5�   *   $ � ��$% 0q�6L   5�   '   )   Columns) 5�   "   0  *System.Windows.Controls.DataGridTextColumn  5�   &   ,	  &System.Windows.Controls.DataGridColumn* 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	* 20*
 5�   )   + 	  Header$+ Código Artículo��5�   )   , 	  
IsReadOnly$
, True��5�   )   1  +System.Windows.Controls.DataGridBoundColumn-   Binding- 5�   )   �� $ CodeArticle�. 	  HeaderTemplate. 5�   *   �� 5�   .   .R�5�   2   �� / �� Orientation$/ Vertical=�6=   .+�5�   6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� RelativeSource0 �� 1 �� Mode$1 TemplatedParent=�6�   �� 5�   6   2 ��Name$2 txtCodeArticleSearch��6>   ��6\   �� $# DataContext.CodeArticleSearch�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+3 �� AncestorType"3  .��6  .  (System.Windows.Interactivity.Interaction4   Triggers4 5�   :   /  )System.Windows.Interactivity.EventTrigger  5   >   5   	EventName$5 KeyUp��6M   .  (System.Windows.Interactivity.TriggerBase6   Actions.6 5  B   /  )GalaSoft.MvvmLight.Command.EventToCommand  7   Command7 6U   �� $+ %DataContext.KeyDownFindArticleCommand�0 �� *FindAncestor+"3  5  ?   .��5  R   5  7   � 5  6   $
��Auto��5  9   $
��Auto��5  9   $��1q�5  9   $��Bottom=�5
  9   ��5	  9   �� $&  DataContext.IsOpenPopCodeArticle�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+"3  8 � PlacementTarget8 5  9   �� 9 �� ElementName$9 txtCodeArticleSearch��.��5  :   �� 
�������
���   �._�5  >   �� $��Center=�6I   $/ Vertical=�6d   .+�5  B     $
��Auto��5  E   $ False��5  E   $ False��5  E   $ False��5  E   $ False��5  E   $
 True��5  E   $  Single=�5  E   $! FullRow=�5  E   ��5  E   �� $ DataContext.FindArticles�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+"3  " 5  E   �� $ DataContext.FindArticle�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+"3  ) 5  F     5  J   $
* Auto
 5  M   $+ Código��5  M   $
, True��5  M   - 5  M   �� $ CodeArticle�5  M     5!  J   $
* Auto
 5"  M   $+ Nombre��5$  M   $
, True��5%  M   - 5#  M   �� $ NameArticle�5%  M   5(  C   5)  ?   5*  ;   5+  7   5,  3   5-  /   :   ElementStyle: 5/  *   �� 50  .   "# ��64   .�51  2   �� $ � ��$% Center=�6V   52  /   54  '     56  &   $	* 40*
 57  )   $+ Nombre��59  )   $
, True��5:  )   - 58  )   �� $ NameArticle�. 5;  *   �� 5<  .   .R�5=  2   �� $/ Vertical=�6=   .+�5>  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5?  6   $2 txtNameArticleSearch��6>   ��6\   �� $# DataContext.NameArticleSearch�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+"3  .��6  4 5A  :     5B  >   $5 KeyUp��6M   .6 5C  B     7 6U   �� $+ %DataContext.KeyDownFindArticleCommand�0 �� *FindAncestor+"3  5D  ?   .��5E  R   5F  7   � 5G  6   $
��Auto��5H  9   $
��Auto��5I  9   $��1q�5J  9   $��Bottom=�5L  9   ��5K  9   �� $&  DataContext.IsOpenPopNameArticle�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+"3  8 5M  9   �� $9 txtNameArticleSearch��.��5N  :   �� 
�������._�5O  >   �� $��Center=�5P  A   $��Center=�5Q  A   $/ Vertical=�5R  A   .+�5S  B     $
��Auto��5T  E   $ False��5U  E   $ False��5V  E   $ False��5W  E   $ False��5X  E   $
 True��5Y  E   $  Single=�5\  E   $! FullRow=�5]  E   ��5Z  E   �� $ DataContext.FindArticles�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+"3  " 5[  E   �� $ DataContext.FindArticle�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+"3  ) 5^  F     5`  J   $
* Auto
 5a  M   $+ Código��5c  M   $
, True��5d  M   - 5b  M   �� $ CodeArticle�5d  M     5f  J   $
* Auto
 5g  M   $+ Nombre��5i  M   $
, True��5j  M   - 5h  M   �� $ NameArticle�5j  M   5m  C   5n  ?   5o  ;   5p  7   5q  3   5r  /   : 5t  *   �� 5u  .   "# ��64   .�5v  2   �� $ � ��$% Center=�6V   5w  /   5y  '   4  .System.Windows.Controls.DataGridTemplateColumn  5z  &   $	* 25*
 6=   $+ Cantidad��6I   ;   CellTemplate; 5{  *   �� 5|  .   .R�5}  2   �� $��Center=�6=   .+�5~  6   �� -   5        < �� TextAlignment$< Right=�5�  9   ��5�  9   �� $ Quantity�$ {0:n2}��$ TwoWay=�$ PropertyChanged=�#
 [ 5�  9   5�  3   5�  /   . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5�  6   -   5        $��70��5�  9   $< Right=�5�  9   ��5�  9   �� $' !DataContext.QuantityArticleSearch�$ {0:n2}��0 �� *FindAncestor+"3  5�  9   5�  3   5�  /   5�  '   4  .System.Windows.Controls.DataGridComboBoxColumn  5�  &   $	* 25*
 5�  )   =   DisplayMemberPath$
= Name��5�  )   $+ Estado��5�  )   >   SelectedValuePath$> StateArticleId��5�  )   ?   SelectedValueBinding? 5�  )   �� $ StateArticleId�$ TwoWay=�@ 	  
Visibility@ 5�  )   �� * DataContext.IsNotPurchaseOrder+A �� Source#A [    BooleanToVisibilityConverter#
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5�  6   $ cbStateArticle��5�  9   $	��200��5�  9   $
 Name��5�  9   $ StateArticleId��5�  9     ComboBoxStyleGrid#��[ 5�  9   ��5�  9   �� $ DataContext.StatesArticle�$ TwoWay=�0 �� *FindAncestor+"3   5�  9   �� $&  DataContext.StateArticleIdSearch�$ TwoWay=�0 �� *FindAncestor+"3  $ PropertyChanged=�5�  9   5�  3   5�  /   B   ElementStyleB 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+"3  $ DataContext.StatesArticle��� 5�  2   $ � ��$% Center=�6V   5�  /   C   EditingElementStyleC 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+"3  $ DataContext.StatesArticle�5�  /   5�  '     5�  &   $	* 25*
 5�  )   $= PackageName��5�  )   $+ Empaque��5�  )   $> 	PackageId��5�  )   ? 5�  )   �� $ 	PackageId�$ TwoWay=�@ 5�  )   �� * DataContext.IsNotPurchaseOrder+#A [ #
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5�  6   $ 
cbPackages��5�  9   $	��200��5�  9   D �� SelectedIndex$D 0��5�  9   $ 	PackageId��5�  9   #��[ 5�  9    5�  9   �� $! DataContext.PackageIdSearch�$ TwoWay=�0 �� *FindAncestor+"3  ��5�  :   -  'System.Windows.Data.CompositeCollection  5�  >   �� 5�  B   E ��Name$E StateArticleId��5�  E   $��Seleccione...��5�  E   F �� 
IsSelected$
F True��5�  E   $y�	Collapsed=�5�  E   �� 5�  B   G �� 
CollectionG 6V   �� #A [ 5�  ?   ��5�  :   �� 5�  >   .R�5�  B   �� .+�5�  F   �� ��6P   �� $ PackageName�5�  C   5�  ?   5�  7   5�  3   5�  /   B 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+"3  $ DataContext.Packages��� 5�  2   $ � ��$% Center=�6V   5�  /   C 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��% 6P   �� 0 �� *FindAncestor+"3  $ DataContext.Packages�5�  /   5�  '     5�  &   $	* 25*
 5�  )   $+ Unidad de Medida��5�  )   $
, True��5�  )   - 5�  )   �� $ UnitMeasure�. 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5�  6   $��Center=�5�  9   $��Center=�5�  9   ��5�  9   �� $* $DataContext.UnitMeasureArticleSearch�0 �� *FindAncestor+"3  5�  3   5�  /   : 5�  *   �� 5�  .   "# ��64   .�5�  2   �� $ � ��$% Center=�6V   5   /   5  '     5  &   $	* 25*
 5  )   $+ Pedido Sugerido��5  )   $
, True��5  )   - 5  )   �� $ SuggestedOrder�#
 [ . 5	  *   �� 5
  .   .R�5  2   �� $/ Vertical=�6=   .+�5  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5  6   ��6>   �� $- 'DataContext.SuggestedOrderArticleSearch�0 �� *FindAncestor+"3  #
 [ 5  3   5  /   : 5  *   �� 5  .   "# ��64   .�5  2   �� $ � ��$% Center=�6V   �� 5  2   $ � ��$% Right=�6X   5  /   5  '     5  &   $	* 25*
 5  )   $+ Stock��5  )   $
, True��5  )   - 5  )   �� $ Stock�#
 [ . 5  *   �� 5  .   .R�5   2   �� $/ Vertical=�6=   .+�5!  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5"  6   ��6>   �� $$ DataContext.StockArticleSearch�0 �� *FindAncestor+"3  #
 [ 5#  3   5$  /   : 5&  *   �� 5'  .   "# ��64   .�5(  2   �� $ � ��$% Center=�6V   �� 5)  2   $ � ��$% Right=�6X   5*  /   5,  '     5.  &   $	* 25*
 5/  )   $+ Mínimo��51  )   $
, True��52  )   - 50  )   �� $ Minimum�#
 [ . 53  *   �� 54  .   .R�55  2   �� $/ Vertical=�6=   .+�56  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 57  6   ��6>   �� $&  DataContext.MinimumArticleSearch�0 �� *FindAncestor+"3  #
 [ 58  3   59  /   : 5;  *   �� 5<  .   "# ��64   .�5=  2   �� $ � ��$% Center=�6V   �� 5>  2   $ � ��$% Right=�6X   5?  /   5A  '     5C  &   $	* 25*
 5D  )   $+ Máximo��5F  )   $
, True��5G  )   - 5E  )   �� $ Maximum�#
 [ . 5H  *   �� 5I  .   .R�5J  2   �� $/ Vertical=�6=   .+�5K  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   �� 5L  6   ��6>   �� $&  DataContext.MaximumArticleSearch�0 �� *FindAncestor+"3  #
 [ 5M  3   5N  /   : 5P  *   �� 5Q  .   "# ��64   .�5R  2   �� $ � ��$% Center=�6V   �� 5S  2   $ � ��$% Right=�6X   5T  /   5V  '     5W  &   $	* 30*
 6=   $+ Observaciones��6I   . 5Y  *   �� 5Z  .   .R�5[  2   �� $/ Vertical=�6=   .+�5\  6   �� $
��Wrap=�6�   ��6@   �� *	Content+0 �� $1 TemplatedParent=�6�   � 5]  6   $��41��5^  9   $��60��5_  9   $��41��5`  9   $
��Left=�5a  9   H � ToolTipH 5b  9   �� $ DataContext.Observation�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+"3  .+�5c  :   �� $
��Wrap=�6�   ��6D   �� $ DataContext.Observation�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+"3  ��5d  >   �� 5e  B   "# ��6H   .�5f  F   �� $ � ��$
% Wrap=�6e   �� 5g  F   $ � ��$% 11(�6a   �� 5h  F   $ � ��% �#0006c   5i  C   H 5k  >   _� 5l  B     CustomToolTip#��[ 6�    6J   �� 0 �� *Self+$ PlacementTarget.Parent�.��5m  F   �� ��6P   �� $ ToolTip���5n  J   �� 5o  N   "# ��6T   .�5p  R   �� $ � ��$
% Wrap=�6q   �� 5q  R   $ � ��$
% Auto��6k   �� 5r  R   $ � ��$% 15(�6m   5s  O   5u  G   5v  C   5y  ;   5z  7   �� 5{  6   $��20��5|  9   $��20��5}  9   $��-10,-20,-10,0q�5~  9   $��0q�5  9   $��Right=�5�  9   ���#FF9800���#FF9800��5�  9   �� $( "DataContext.CmdOpenEditObservation�0 �� *FindAncestor+"3  .��5�  :     $��Center=�6R   $
 Edit=�6o   5�  7   � 5�  6   I �Name$I 	InfoPopup��5�  9   J � AllowsTransparency$
J True��5�  9   $��Bottom=�5�  9   K � 	StaysOpen$K False��5�  9   ��5�  9   �� $&  DataContext.IsPopObservationOpen�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+"3  .��5�  :   �� L ��Name$L InfoPopupBorder��5�  =   $	��200��5�  =   $	��100��5�  =   M K� ZIndex$M 10��5�  =   
�������
�������$��1q�5�  =   N �� CornerRadius$N 5��5�  =   O J� EffectO 5�  >   3  -System.Windows.Media.Effects.DropShadowEffect  5�  B   P   
BlurRadius$P 10Q�5�  E   Q   	Direction$	Q 270Q�5�  E   R   Opacity$	R 0.5Q�5�  E   S   ShadowDepth$S 7Q�5�  E   ._�5�  >   �� $2 TextAreaPopup��5�  A   T �� AcceptsReturn$
T True��5�  A   
�������U �� 	MaxLength$	U 100��5�  A   V �� TextWrapping$
V Wrap=�5�  A   "W �� VerticalScrollBarVisibility$W Visible=�5�  A   ��5�  A   �� $ DataContext.Observation�$ TwoWay=�$ PropertyChanged=�0 �� *FindAncestor+"3  5�  A   5�  ;   5�  7   5�  3   5�  /   ; 5�  *   �� 5�  .   .R�5�  2   �� .+�5�  6   � $��41��5�  9   $��60��5�  9   $��41��5�  9   $
��Left=�5�  9   H 5�  9   �� *Observations+$ TwoWay=�$ PropertyChanged=�.+�5�  :   �� $
��Wrap=�6�   ��6D   �� *Observations+$ TwoWay=�$ PropertyChanged=���5�  >   �� 5�  B   "# ��6H   .�5�  F   �� $ � ��$
% Wrap=�6e   �� 5�  F   $ � ��$% 11(�6a   �� 5�  F   $ � ��% �#0006c   5�  C   H 5�  >   _� 5�  B   #��[ 6�    6J   �� 0 �� *Self+$ PlacementTarget.Parent�.��5�  F   �� ��6P   �� $ ToolTip���5�  J   �� 5�  N   "# ��6T   .�5�  R   �� $ � ��$
% Wrap=�6q   �� 5�  R   $ � ��$
% Auto��6k   �� 5�  R   $ � ��$% 15(�6m   5�  O   5�  G   5�  C   5�  ;   5�  7   �� 5�  6   $��20��5�  9   $��20��5�  9   $��-10,-20,-10,0q�5�  9   $��0q�5�  9   $��Right=�5�  9   ���#FF9800���#FF9800��5�  9   �� $, &DataContext.CmdOpenEditObservationItem�0 �� *FindAncestor+"3  ��5�  9   �� $ .�.��5�  :     $��Center=�6R   $
 Edit=�6o   5�  7   � 5�  6   $I 	InfoPopup��5�  9   $
J True��5�  9   $��Bottom=�5�  9   $K False��5�  9   ��5�  9   �� *IsPopObservationOpen+$ TwoWay=�$ PropertyChanged=�.��5�  :   �� $L InfoPopupBorder��5�  =   $	��200��5�  =   $	��100��5�  =   $M 10��5�  =   
�������
�������$��1q�5�  =   $N 5��5�  =   O 5�  >     5�  B   $P 10Q�5�  E   $	Q 270Q�5�  E   $	R 0.5Q�5�  E   $S 7Q�5�  E   ._�5�  >   �� $2 TextAreaPopup��5�  A   $
T True��5�  A   
�������$
V Wrap=�5�  A   $W Visible=�5�  A   ��5�  A   �� *Observations+$ TwoWay=�$ PropertyChanged=�5�  A   5�  ;   5�  7   5�  3   5�  /   5�  '     5�  &   $	* 25*
 6=   @ 6I   �� *DataContext.IsCraftOrder+#A [ #
 [ . 5�  *   �� 5�  .   .R�5�  2   �� $/ Vertical=�6=   .+�5�  6   �� $��20,0,0,5q�5   9   $��Agregar��5  9   $
��Wrap=�5  9   y�5  9   �� $ DataContext.IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 0 �� *FindAncestor+"3  �� 5  6   $��30��5  9   $��30��5  9   $��25,0,5,0q�5  9   $��0q�5  9   $��Center=�5	  9   $��Center=�5
  9   ���#4CAF50���#4ACF50$��13q�5  9   ��5  9   �� $, &DataContext.ValidateFindArticleCommand�0 �� *FindAncestor+"3  y�5  9   �� $ DataContext.IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 0 �� *FindAncestor+"3  .��5  :     $��Center=�6R   $	 Add=�6o   5  7   5  3   5  /   ; 5  *   �� 5  .   .R�5  2   �� $��Center=�5  5   $��Center=�5  5   $/ 
Horizontal=�5  5   .+�5  6   �� $��30��5  9   $��30��5  9   $��5,0,5,0q�5  9   $��0q�5  9   $��Center=�5   9   $��Center=�5!  9   
���  ��
���  ��$��13q�5$  9   ��5%  9   �� $+ %DataContext.DeleteArticleOrderCommand�0 �� *FindAncestor+"3  y�5&  9   �� $ DataContext.IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 0 �� *FindAncestor+"3  .��5'  :     $��Center=�6R   $ Trash=�6o   5(  7   5)  3   5*  /   5,  '   5/     50     �� 52     $
��0,20q�53     $��Right=�54     $��Bottom=�55     $/ 
Horizontal=�56     .+�57     �� -   5        X ��Name$X btnCleanPage��58  !   $��0,0,5,0q�59  !   
���  ��
���  ��$��Limpiar solicitud��5=  !   ��5<  !   �� *DeleteArticlesOrderCommand+{�5>  !   �� *EnableCleanOrder+y�5?  !   �� $ IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ �� 5@     -   5        $X btnSelectArticles��5A  !   $��0,0,5,0q�5B  !   ���#00BCD4���#00BCD4$��Agregar Artículos(F3)��5F  !   ��5E  !   �� *ShowModalArticlesCommand+y�5G  !   �� $ IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ �� 5H     -	   5        $X btnSave��5I  !   $��0,0,5,0q�5J  !   ���#FF9800���#FF9800$��Guardar Borrador��5N  !   ��5M  !   �� *!ValidateOpenConfirmationCommand+{�5O  !   �� *EnableSavedAndSendOrder+y�5P  !   �� $ IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ �� 5Q     -
   5        $X btnSend��5R  !   $��0,0,5,0q�5S  !   ���#4ACF50���#4ACF50$��Actualizar Documento��5W  !   ��5V  !   �� *#!ValidateErasedConfirmationCommand+{�5X  !   �� *EnableSavedAndSendOrder+y�5Y  !   �� $ IsNotCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ �� 5Z     -   5        $X btnEdit��5[  !   $��0,0,5,0q�5\  !   ���#4ACF50���#4ACF50$��Generar Documento��5`  !   ��5_  !   �� *#!ValidateErasedConfirmationCommand+{�5a  !   �� *EnableSavedAndSendOrder+y�5b  !   �� $ IsCraftOrder�$ TwoWay=�$ PropertyChanged=�#
 [ 5c     5e     5f     5g     � 5i       IconCard#��[ 6   O 5j       5k     $P 20Q�5l     Y   RenderingBias$Y Quality=�5m     $S 1Q�5n     Z   Color$Z 	#FFECECEC��5o     .+�5q     ��   
BorderCard#��[ 6     5r     $��30��5s     $��30��5t     $��5q�5u     $��10q�5v     $��Center=�5w     $��Center=�5x     
�������$ PlaylistAddCheck=�5z     5{     � 5}      	 Title#��[ 6   .+�5     ��   ContentTitle#��[ 6   .+�5�     ��   	TextTitle#��[ 6    ��6C   �� *OrderType.OrderTypeName+$% Solicitud de Pedido - Tipo: {0}��5�     5�     5�     5�     5�     