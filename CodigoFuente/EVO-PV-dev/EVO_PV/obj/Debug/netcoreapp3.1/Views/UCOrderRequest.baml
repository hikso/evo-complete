   M S B A M L   `   `   `  ����e  aPresentationFramework.AeroLite, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35kNclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroLiteMicrosoft.Windows.Themes  5      A =EVO_PV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EVO_PV.UtilitiesEVO_PV.Utilities 5	      !   EVO_PV.Views.UCOrderRequest   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      aThemesNclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroLite     5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      *localclr-namespace:EVO_PV.Utilities  5	      Llocal19http://schemas.microsoft.com/winfx/2006/xaml/presentation     5
      U	 QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5      -   5          >�Name$  UserControl��5      $
|�True��5      ��5      ��  �� Path$ WidthForUserControl� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� � 	Resources 5       �� MergedDictionaries �� Source   	Factories �� Source  FactorieTypes  StatesArticle  Packages  VisibilityConverterBool�� 5   
    5      �� 5      $< 6/EVO_PV;Component/Resources/Dictionaries/DictTags.xaml?�6%   �� 5      $2 ,/EVO_PV;Component/Resources/Style/style.xaml?�6%   %�  &	        &	 O     &	 �     &	 �     &	 C    �� 5       65   �� $ 	Factories�$ TwoWay=�$ PropertyChanged=��� 5       69   �� $ FactorieTypes�$ TwoWay=�$ PropertyChanged=��� 5       69   �� $ StatesArticle�$ TwoWay=�$ PropertyChanged=��� 5       64   �� $ Packages�$ TwoWay=�$ PropertyChanged=��� 5      6+   5      .��5!      � $
��Auto��6   ���#eee � ColumnDefinitions 5#   
   �� 5$      $��* �6   	 � RowDefinitions	 5'   
   �� 5(      .+�5*   
   �� $��0��5+      $	��150��5,      $��0,0,40,0q�5-      $��0q�5.      $��Right=�5/      $	��Top=�50      ���#00BCD4���#00BCD4 " MaterialDesignRaisedDarkButton#��[ 54      ��53      �� $ ViewDetailsCraft�.��55      � $	��150��6   $��Center=�6   .+�56      ' 	 !MaterialDesignThemes.Wpf.PackIcon  $��10,2,0,0q�57      ���#FFFFFF
   Kind$
 ChevronLeft=�59      �� 5:      $��Center=�6   $��REGRESAR��69   5;      5<      � 5>   
   $��0��5?      $
��Auto��5@      $��0,40,0,0q�5A      .+�5C      # 	 MaterialDesignThemes.Wpf.Card  $��1��6"   $��
30,0,30,10q�6/   .��5E      � $
��Auto��6     ContentCard#��[ 6$    5G      �� 5H      	 5K      �� 5L      $��80 �6(   �� 5M      $
��Auto �6(   �� 5N      �� 5O      .+�5R      �� $��0��6!   .+�5T      � $��	0,10,0,20q�6    5V      �� 5W   "   $��1* �63   �� 5X   "   $
��1.3* �63   �� 5Y   "   $��1* �63   �� 5Z   "   $��1* �63   	 5]      �� 5^   "   .+�5a      �� $��0��5b   !   $��0��5c   !     
HeaderView#��[ 5d   !   .+�5f   "   ��   TextHeaderView#��[ 6,    	 lblDateRequest#��� 	 6T   �� 5h   "    
 DateCreation#��[
 6,   ��6R   �� $ PropertyChanged=� �� StringFormat$ 
dd/MM/yyyy��$ 	DateOrder� �� ValidatesOnDataErrors$
 True�� �� NotifyOnValidationError$
 True��$ OneWay=�5j      �� 5l      $��0��5m   !   $��1��5n   !   #��[ 5o   !   .+�5q   "   �� #��[ 6,     lblDateDelivery#���  6T   (  "System.Windows.Controls.DatePicker  5s   "   -   5        $��dpDateDelivery��5t   %   $	��110��5u   %   $��
10,-4,-1,0q�5v   %   $��Bottom=�5w   %   ���	#FFECECEC$|�False��5y   %      IsTodayHighlighted$ False��5{   %    � Language$ ES-mx�5|   %      IsDropDownOpen 5z   %   �� $
 Open�   SelectedDate 5~   %   �� $ DateDelivery�$ TwoWay=�$
 True��$
 True��$ 	LostFocus=� 5   &     PrimaryHueMidBrush �� Color  MaterialDesignBody��%T   &	       &	 !     �� 5�   *   $ #FF9800��6U   �� 5�   *   $ Black��6U   5�   '   5�   #   5�      �� 5�      $��0��5�   !   $��2��5�   !   $��2��5�   !   #��[ 5�   !   y�5�   !   �� $ IsPurchaseOrder�$ TwoWay=�$ PropertyChanged=� �� 	Converter# [ .+�5�   "   �� #��[ 6,     lblRequestFor#���  6T   �� 5�   "   #��[
 6,   $��Área de Compras��6R   5�      �� 5�      $��0��5�   !   $��2��5�   !   $��2��5�   !   #��[ 5�   !   y�5�   !   �� $ IsNotPurchaseOrder�$ TwoWay=�$ PropertyChanged=�# [ .+�5�   "   �� #��[ 6,   #���  6T   �� 5�   "   -   5         ��Name$ 	cbPlantas��5�   %    �� SelectedIndex$ 0��5�   %    �� SelectedValuePath$ WhsTypeName��5�   %     ComboBoxStyle#��[ 5�   %    �� SelectedValue 5�   %   �� $ FactoryTypeSelectedName�$ TwoWay=�$ PropertyChanged=���5�   &   -  'System.Windows.Data.CompositeCollection  5�   *   �� 5�   .   -   5         ��Name$ WhsTypeName��5�   1   $��Seleccione...��5�   1    �� 
IsSelected$
 True��5�   1   $y�	Collapsed=�5�   1   �� 5�   .    �� 
Collection 6B   ��  �� Source# [ 5�   +   ��5�   &   �� 5�   *   .R�5�   .   �� .+�5�   2   �� ��6<   �� $ WhsTypeName�5�   /   5�   +   5�   #   �� 5�   "   -   5        $ cbPlantasSelecionada��5�   %   $ 0��5�   %   $ WhsCode��5�   %   #��[ 5�   %    �� Text$ Seleccione...��5�   %   {�5�   %   �� $ IsNotFactory�$ TwoWay=�$ PropertyChanged=� 5�   %   �� $ FactoryCode�$ TwoWay=�$ PropertyChanged=���5�   &     5�   *   �� 5�   .   -   5        $ Codigo��5�   1   $��Seleccione...��5�   1   $
 True��5�   1   $y�	Collapsed=�5�   1   �� 5�   .    6B   �� # [  5�   +   ��5�   &   �� 5�   *   .R�5�   .   �� .+�5�   2   �� ��6<   �� $ WhsName�5�   /   5�   +   5�   #   5�      5�      5�      �� 5�      $��1��5�      $��	0,-25,0,1q�5�       �� Padding$ 	15,15,0,0q�5�       K� ZIndex$ 10��5�      
���   �$��.1q�5�       �� CornerRadius$ 10��5�      ._�5�      �� -   5          ��Name$  StackSearch��5�   %   .+�5�      �  5�   "   �� 5�   &   $	��10* �67   �� 5�   &   $	��20* �67   �� 5�   &   $	��20* �67   �� 5�   &   $	��20* �67   	 5�   "   �� 5�   &   �� 5�   &   �� 5�   &   .+�5�   "   �� $��0��5�   %   $��0��5�   %   $��1��5�   %   $	��130��5�   %   $
��Left=�5�   %   .+�5�   &   �� $��0q�5�   )   #��[ 5�   )   $��Código Artículo��5�   )   $
��Wrap=�5�   )   �� 5�   &   -   5        ! ��Name$! txtCodeArticleSearch��5�   .   ��6L   �� $ CodeArticleSearch�$ TwoWay=�$ PropertyChanged=�� 5�   &   $
��Auto��5�   )   $
��Auto��5�   )   $��1q�5�   )   $��Bottom=�5�   )   " � 	StaysOpen$" False��5�   )   ��5�   )   �� $ IsOpenPopCodeArticle�$ TwoWay=�$ PropertyChanged=�# � PlacementTarget# 5�   )   �� $ �� ElementName$$ txtCodeArticleSearch��.��5�   *   �� 
�������
���   �$��0q�5�   -   ._�5  .   �� $��Center=�5  1   $��Center=�5  1   % �� Orientation$% Vertical=�5  1   .+�5  2   &   System.Windows.Controls.DataGrid  $
��Auto��5  5   &   AutoGenerateColumns$& False��5  5   '   CanUserAddRows$' False��5	  5   (   CanUserDeleteRows$( False��5
  5   )   CanUserReorderColumns$) False��5  5   *   CanUserResizeColumns$
* True��5  5   +   SelectionMode$+ Single=�5  5   ,   SelectionUnit$, FullRow=�5  5   ��5  5   �� $ FindArticles�$ TwoWay=�$ PropertyChanged=�- �� SelectedItem- 5  5   �� $ FindArticle�$ TwoWay=�$ PropertyChanged=�.   Columns. 5  6   0  *System.Windows.Controls.DataGridTextColumn  5  :   ,  &System.Windows.Controls.DataGridColumn/   Width5  /System.Windows.Controls.DataGridLengthConverter$
/ Auto 5  =   0   Header$0 Código��5  =   1   
IsReadOnly$
1 True��5  =   1	  +System.Windows.Controls.DataGridBoundColumn2 	  Binding2 5  =   �� $ CodeArticle�5  =     5  :   $
/ Auto 5  =   $0 Nombre��5  =   $
1 True��5  =   2 5  =   �� $ NameArticle�5  =   5"  3   5$  /   5&  +   5(  '   5*  #   �� 5+  "   $��0��5,  %   $��1��5-  %   $% Vertical=�5.  %   .+�5/  &   �� $��0q�50  )   #��[ 51  )   $��Nombre��52  )   $
��Wrap=�53  )   �� 54  &   -	   5        $! txtNameArticleSearch��54  .   ��6L   �� $ NameArticleSearch�$ TwoWay=�$ PropertyChanged=�� 55  &   $
��Auto��56  )   $
��Auto��57  )   $��1q�58  )   $��Bottom=�5:  )   $" False��5<  )   ��59  )   �� $ IsOpenPopNameArticle�$ TwoWay=�$ PropertyChanged=�# 5;  )   �� $$ txtNameArticleSearch��.��5=  *   �� 
�������._�5>  .   �� $��Center=�5?  1   $��Center=�5@  1   $% Vertical=�5A  1   .+�5C  2     $
��Auto��5D  5   $& False��5E  5   $' False��5F  5   $( False��5G  5   $) False��5H  5   $
* True��5I  5   $+ Single=�5L  5   $, FullRow=�5M  5   ��5J  5   �� $ FindArticles�$ TwoWay=�$ PropertyChanged=�- 5K  5   �� $ FindArticle�$ TwoWay=�$ PropertyChanged=�. 5N  6     5P  :   $
/ Auto 5Q  =   $0 Código��5S  =   $
1 True��5T  =   2 5R  =   �� $ CodeArticle�5T  =     5V  :   $
/ Auto 5W  =   $0 Nombre��5Y  =   $
1 True��5Z  =   2 5X  =   �� $ NameArticle�5Z  =   5^  3   5_  /   5`  +   5a  '   5b  #   �� 5c  "   $��1��5d  %   $��0��5e  %   $	��130��5f  %   $
��Left=�5g  %    5h  &   '
  !EVO_PV.Utilities.DecimalConverter  decimalConverter�� 5i  *   %   &	       
  5j  .   6E   5k  +   .+�5m  &   �� $��0q�5n  )   #��[ 5o  )   $��Cantidad��5p  )   $
��Wrap=�5q  )   �� 5s  &   -
   5        $! Quantity��5t  )   $��Center=�5u  )   $
|�True��5v  )   3 �� TextAlignment$3 Right=�5{  )   ��5z  )   �� *QuantityArticleSearch+$ TwoWay=�$ PropertyChanged=�# [ 5{  )   5|  #   �� 5}  "   $��1��5~  %   $��1��5  %   $
��Left=�5�  %   y�5�  %   �� *IsNotPurchaseOrder+   BooleanToVisibilityConverter# [ .+�5�  &   �� $��0q�5�  )   #��[ 5�  )   $��Estado��5�  )   $
��Wrap=�5�  )   �� 5�  &   -   5        $ cbStateArticle��5�  )   $	��200��5�  )   $ 0��5�  )   $ StateArticleId��5�  )     ComboBoxStyleGrid#��[ 5�  )    5�  )   �� $ StateArticleIdSearch�$ TwoWay=���5�  *     5�  .   �� 5�  2   -   5        $ StateArticleId��5�  5   $��Seleccione...��5�  5   $
 True��5�  5   $y�	Collapsed=�5�  5   �� 5�  2    6F   �� # [ 5�  /   ��5�  *   �� 5�  .   .R�5�  2   �� .+�5�  6   �� ��6@   �� $
 Name�5�  3   5�  /   5�  '   5�  #   �� 5�  "   $��1��5�  %   $��2��5�  %   $
��Left=�5�  %   y�5�  %   �� *IsNotPurchaseOrder+# [ .+�5�  &   �� $��0q�5�  )   #��[ 5�  )   $��Empaque��5�  )   $
��Wrap=�5�  )   �� 5�  &   -   5        $ 
cbPackages��5�  )   $	��200��5�  )   $ 0��5�  )   $ 	PackageId��5�  )   #��[ 5�  )    5�  )   �� $ PackageIdSearch�$ TwoWay=���5�  *     5�  .   �� 5�  2   -   5        $ 	PackageId��5�  5   $��Seleccione...��5�  5   $
 True��5�  5   $y�	Collapsed=�5�  5   �� 5�  2    6F   �� # [ 5�  /   ��5�  *   �� 5�  .   .R�5�  2   �� .+�5�  6   �� ��6@   �� $ PackageName�5�  3   5�  /   5�  '   5�  #   �� 5�  "   $��0��5�  %   $��2��5�  %   $��3��5�  %   $
��Left=�5�  %   .+�5�  &   �� $��0q�5�  )   #��[ 5�  )   $��Observación��5�  )   $
��Wrap=�5�  )   �� 5�  &   $ 5q�5�  )   
���   �$��.3q�5�  )   $ 5��5�  )   ._�5�  *   �� $% Vertical=�65   .+�5�  .   � $	��250��5�  1   $��70��5�  1   $
��Left=�5�  1   4 � ToolTip4 5�  1   �� $ Observation�$ TwoWay=�$ PropertyChanged=�.+�5�  2   �� -   5        $! TextAreaPopup��5�  5   5 �� AcceptsReturn$
5 True��5�  5   
�������$��0q�5�  5   6 �� 	MaxLength$	6 100��5�  5   7 �� TextWrapping$
7 Wrap=�5�  5   "8 �� VerticalScrollBarVisibility$8 Visible=�5�  5   ��5�  5   �� $ Observation�$ TwoWay=�$ PropertyChanged=�5�  5   5�  /   5�  +   5�  '   5�  #   �� 5�  "   $��2��5�  %   $��0��5�  %   $
��Left=�5�  %   .+�5�  &   �� $��0q�5�  )   #��[ 5�  )   $��Unidad de Medida��5�  )   $
��Wrap=�5�  )   �� 5�  &   9 �� TextAlignment$
9 Left=�6_   ��60   �� $ UnitMeasureArticleSearch�6_   5�  #   �� 5�  "   $��2��5�  %   $��1��5�  %   $
��Left=�5�  %    5�  &   �� 5�  *   %   &	       
  5�  .   6E   5�  +   .+�5   &   �� $��0q�5  )   #��[ 5  )   $��Pedido Sugerido��5  )   $
��Wrap=�5  )   �� 5  &   $
9 Left=�6�   ��60   �� $! SuggestedOrderArticleSearch�# [ 6�   5  #   �� 5  "   $��2��5  %   $��2��5	  %   $
��Left=�5
  %    5  &   �� 5  *   %   &	       
  5  .   6E   5  +   .+�5  &   �� $��0q�5  )   #��[ 5  )   $��Stock��5  )   $
��Wrap=�5  )   �� 5  &   $
9 Left=�6�   ��60   �� $ StockArticleSearch�# [ 6�   5  #   �� 5  "   $��2��5  %   $��3��5  %   $
��Left=�5  %    5  &   �� 5  *   %   &	       
  5  .   6E   5  +   .+�5   &   �� $��0q�5!  )   #��[ 5"  )   $��Stock Mínimo/Máximo��5#  )   $
��Wrap=�5$  )   �� 5%  &   $
9 Left=�60   ��5&  *   `� 5'  .   $ 	{0} / {1}��6;   .1�5(  2   �� # [ 6:   $ MinimumArticleSearch�6h   �� 5)  2   # [ 6:   $ MaximumArticleSearch�6h   5*  /   5,  '   5-  #   �� 5.  "   $��3��6-   $��3��6:   .+�5/  &   �� $	��100��50  )   $��40��51  )   $��
140,20,0,0q�52  )   $��Center=�53  )   $��Center=�54  )   ���#4CAF50���#4ACF50$��20q�57  )   $��Agregar��59  )   ��58  )   �� $  ValidateFindArticleCommand�59  )   5:  #   5;     5<     5>     �� 5@     -   5        $  ParentStack��5@  !   $��2��66    5A       ProxyElement: � DataContext��%C   &	       &	      �� 5B     6B   � 5D     : 6D   �� 5E     .+�5F     �� #��[ 6)   $y�	Collapsed=�6Q     5G     -   5        ;  Name$; dgOrderArticles��5H     $��2��5I     $��3��5J     $	��370��5L     $��Stretch=�5M     $��Stretch=�5N     $& False��5O     
�������$' False��5Q     $
( True��5R     $) False��5S     $* False��5T       SuojiHeaderStyle<   ColumnHeaderStyle#< [ 5U     !=   EnableColumnVirtualization$= False��5V     $
��True��5X     $
��Auto=�5Y     $
��Auto=�5Z     $+ Single=�5\     $, FullRow=�5]     ��5K     �� $$ ParentStack��$ ActualWidth���5W     �� *ArticlesOrder+- 5[     �� *ArticleOrderSelected+ 5`     �� 5a  "   %   &	       
  5b  &   6=   5c  #   ��5f     �� 5g  "   > �� 
TargetType)  #System.Windows.Controls.DataGridRow">  6(   .�5h  &   �� ? �� Property? � ��@ �� Value@ 6C   �� $ ErrorArticle�$ TwoWay=�$ PropertyChanged=��� 5i  &   ? � ��$@ 0,0,0,0q�6?   �� 5j  &   ? � ��$@ 0q�6H   5k  #   A   RowStyleA 5m     �� 5n  "   ">  6(   .�5o  &   �� ? � ��$
@ Auto��6?   �� 5p  &   ? � ��$
@ Auto��6>   5q  #   . 5s       5u  "   $
/ Auto 5v  %   $0 Código Artículo��5x  %   $
1 True��5y  %   2 5w  %   �� $ CodeArticle�B   HeaderTemplateB 5{  &   �� 5|  *   .R�5}  .   �� $% Vertical=�69   .+�5~  2   �� $
��Wrap=�6�   ��6<   �� *	Content+C �� RelativeSourceC �� D �� Mode$D TemplatedParent=�6�   5  /   5�  +   E 	  ElementStyleE 5�  &   �� 5�  *   "> ��60   .�5�  .   �� ? � ��$@ Center=�6R   5�  +   5�  #     5�  "   $	/ 200 5�  %   $0 Nombre��5�  %   $
1 True��5�  %   2 5�  %   �� $ NameArticle�B 5�  &   �� 5�  *   .R�5�  .   �� $% Vertical=�69   .+�5�  2   �� $
��Wrap=�6�   ��6<   �� *	Content+C �� $D TemplatedParent=�6�   5�  /   5�  +   E 5�  &   �� 5�  *   "> ��60   .�5�  .   �� ? � ��$@ Center=�6R   �� 5�  .   ? � ��$
@ Auto��6F   5�  +   5�  #   4  .System.Windows.Controls.DataGridTemplateColumn  5�  "   $	/ 100 5�  %   $0 Cantidad��5�  %   F   SortMemberPath$F Quantity��5�  %   B 5�  &   �� 5�  *   .R�5�  .   �� $% Vertical=�69   .+�5�  2   �� $
��Wrap=�6�   ��6<   �� *	Content+C �� $D TemplatedParent=�6�   5�  /   5�  +   G   CellTemplateG 5�  &   �� 5�  *   .R�5�  .   � $��Center=�63   H +� FocusedElementH 6N   �� $$ Quantity��.+�5�  2   �� $! Quantity��5�  5   -   5        $��Center=�5�  5   $
|�True��5�  5   $3 Right=�5�  5   ��5�  5   �� *
Quantity+$ TwoWay=�$ PropertyChanged=�# [ 5�  5   5�  /   5�  +   5�  #   4  .System.Windows.Controls.DataGridComboBoxColumn  5�  "   $	/ 100 5�  %   I   DisplayMemberPath$
I Name��5�  %   $0 Estado��5�  %   J   SelectedValuePath$J StateArticleId��5�  %   K   SelectedValueBindingK 5�  %   �� $ StateArticleId�$ TwoWay=�L   
VisibilityL 5�  %   �� * DataContext.IsNotPurchaseOrder+# [ # [ B 5�  &   �� 5�  *   .R�5�  .   �� $% Vertical=�69   .+�5�  2   �� $
��Wrap=�6�   ��6<   �� *	Content+C �� $D TemplatedParent=�6�   5�  /   5�  +   M   ElementStyleM 5�  &   �� 5�  *   "> ��60   .�5�  .   �� ? � ��@ 6L   �� C �� *FindAncestor+N �� AncestorType"N  $ DataContext.StatesArticle��� 5�  .   ? � ��$@ Center=�6R   5�  +   O   EditingElementStyleO 5�  &   �� 5�  *   "> ��60   .�5�  .   �� ? � ��@ 6L   �� C �� *FindAncestor+"N  $ DataContext.StatesArticle�5�  +   5�  #     5�  "   $	/ 110 5�  %   $I PackageName��5�  %   $0 Empaque��5�  %   $J 	PackageId��5�  %   K 5�  %   �� $ 	PackageId�$ TwoWay=�$ PropertyChanged=�L 5�  %   �� * DataContext.IsNotPurchaseOrder+# [ # [ B 5�  &   �� 5�  *   .R�5�  .   �� $% Vertical=�69   .+�5�  2   �� $
��Wrap=�6�   ��6<   �� *	Content+C �� $D TemplatedParent=�6�   5�  /   5�  +   M 5�  &   �� 5�  *   "> ��60   .�5�  .   �� ? � ��@ 6L   �� C �� *FindAncestor+"N  $ DataContext.Packages��� 5�  .   ? � ��$@ Center=�6R   5�  +   O 5�  &   �� 5�  *   "> ��60   .�5�  .   �� ? � ��@ 6L   �� C �� *FindAncestor+"N  $ DataContext.Packages�5�  +   5�  #     5�  "   $	/ 100 5�  %   $0 Unidad de Medida��5�  %   $
1 True��5�  %   2 5�  %   �� $ UnitMeasure�B 5�  &   �� 5�  *   .R�5�  .   �� $% Vertical=�69   .+�5�  2   �� $
��Wrap=�6�   ��6<   �� *	Content+C �� $D TemplatedParent=�6�   5   /   5  +   E 5  &   �� 5  *   "> ��60   .�5  .   �� ? � ��$@ Center=�6R   5  +   5  #     5
  "   $	/ 100 5  %   $0 Pedido Sugerido��5  %   $
1 True��5  %   $F SuggestedOrder��5  %   2 5  %   �� $ SuggestedOrder�# [ B 5  &   �� 5  *   .R�5  .   �� $% Vertical=�69   .+�5  2   �� $
��Wrap=�6�   ��6<   �� *	Content+C �� $D TemplatedParent=�6�   5  /   5  +   E 5  &   �� 5  *   "> ��60   .�5  .   �� ? � ��$@ Right=�6T   �� 5  .   ? � ��$@ Center=�6R   5  +   5  #     5  "   $	/ 100 5   %   $0 Stock��5"  %   $
1 True��5#  %   $F Stock��5$  %   2 5!  %   �� $ Stock�# [ B 5%  &   �� 5&  *   .R�5'  .   �� $% Vertical=�69   .+�5(  2   �� $
��Wrap=�6�   ��6<   �� *	Content+C �� $D TemplatedParent=�6�   5)  /   5*  +   E 5,  &   �� 5-  *   "> ��60   .�5.  .   �� ? � ��$@ Right=�6T   �� 5/  .   ? � ��$@ Center=�6R   50  +   52  #     54  "   $	/ 100 55  %   $0 Mínimo��57  %   $
1 True��58  %   2 56  %   �� $ Minimum�# [ B 59  &   �� 5:  *   .R�5;  .   �� $% Vertical=�69   .+�5<  2   �� $
��Wrap=�6�   ��6<   �� *	Content+C �� $D TemplatedParent=�6�   5=  /   5>  +   E 5@  &   �� 5A  *   "> ��60   .�5B  .   �� ? � ��$@ Right=�6T   �� 5C  .   ? � ��$@ Center=�6R   5D  +   5F  #     5H  "   $	/ 100 5I  %   $0 Máximo��5K  %   $
1 True��5L  %   2 5J  %   �� $ Maximum�# [ B 5M  &   �� 5N  *   .R�5O  .   �� $% Vertical=�69   .+�5P  2   �� $
��Wrap=�6�   ��6<   �� *	Content+C �� $D TemplatedParent=�6�   5Q  /   5R  +   E 5T  &   �� 5U  *   "> ��60   .�5V  .   �� ? � ��$@ Right=�6T   �� 5W  .   ? � ��$@ Center=�6R   5X  +   5Z  #     5[  "   $	/ 100 69   $0 Observación��6E   B 5]  &   �� 5^  *   .R�5_  .   �� $% Vertical=�69   .+�5`  2   �� $
��Wrap=�6�   ��6<   �� *	Content+C �� $D TemplatedParent=�6�   5a  /   5b  +   G 5d  &   �� 5e  *   .R�5f  .   �� .+�5g  2   � $��41��5h  5   $��60��5i  5   $��41��5j  5   $
��Left=�5k  5   4 5l  5   �� *Observations+$ TwoWay=�$ PropertyChanged=�.+�5m  6   �� $
��Wrap=�6�   ��6@   �� *Observations+$ TwoWay=�$ PropertyChanged=���5n  :   �� 5o  >   "> ��6D   .�5p  B   �� ? � ��$
@ Wrap=�6a   �� 5q  B   ? � ��$@ 11(�6]   �� 5r  B   ? � ��@ �#0006_   5s  ?   4 5u  :   _� 5v  >     CustomToolTip#��[ 6�   : 6F   �� C �� *Self+$ PlacementTarget.Parent�.��5w  B   �� ��6L   �� $ ToolTip���5x  F   �� 5y  J   "> ��6P   .�5z  N   �� ? � ��$
@ Wrap=�6m   �� 5{  N   ? � ��$
@ Auto��6g   �� 5|  N   ? � ��$@ 15(�6i   5}  K   5  C   5�  ?   5�  7   5�  3   �� 5�  2   $��20��5�  5   $��20��5�  5   $��-10,-20,-10,0q�5�  5   $��0q�5�  5   $��Right=�5�  5   ���#FF9800���#FF9800��5�  5   �� $, &DataContext.CmdOpenEditObservationItem�C �� *FindAncestor+"N  ��5�  5   �� $ .�.��5�  6     $��Center=�6N   $

 Edit=�6k   5�  3   � 5�  2   P �Name$P 	InfoPopup��5�  5   Q � AllowsTransparency$
Q True��5�  5   $��Bottom=�5�  5   $" False��5�  5   ��5�  5   �� *IsPopObservationOpen+$ TwoWay=�$ PropertyChanged=�.��5�  6   �� R ��Name$R InfoPopupBorder��5�  9   $	��200��5�  9   $	��100��5�  9   $ 10��5�  9   
�������
�������$��1q�5�  9   $ 5��5�  9   S J� EffectS 5�  :   3  -System.Windows.Media.Effects.DropShadowEffect  5�  >   T   
BlurRadius$T 10Q�5�  A   U   	Direction$	U 270Q�5�  A   V   Opacity$	V 0.5Q�5�  A   W   ShadowDepth$W 7Q�5�  A   ._�5�  :   �� $! TextAreaPopup��5�  =   $
5 True��5�  =   
�������$	6 100��5�  =   $
7 Wrap=�5�  =   $8 Visible=�5�  =   ��5�  =   �� *Observations+$ TwoWay=�$ PropertyChanged=�5�  =   5�  7   5�  3   5�  /   5�  +   5�  #     5�  "   $
/ Auto 69   B 5�  &   �� 5�  *   .R�5�  .   �� $��Center=�69   $% Vertical=�6V   $y�	Collapsed=�6m   .+�5�  2   �� $��Agregar��5�  5   $9 Center=�5�  5   $
��Wrap=�5�  5   5�  /   5�  +   G 5�  &   �� 5�  *   .R�5�  .   �� $��30��5�  1   $��30��5�  1   $��5,0,5,0q�5�  1   $��0q�5�  1   $��Center=�5�  1   
���  ��
���  ��$��13q�5�  1   ��5�  1   �� $+ %DataContext.DeleteArticleOrderCommand�C �� *FindAncestor+"N  .��5�  2     $��Center=�6J   $
 Trash=�6g   5�  /   5�  +   5�  #   5�     5�     �� 5�     $��3��5�     $
��0,20q�5�     $��Right=�5�     $��Bottom=�5�     $% 
Horizontal=�5�     .+�5�     �� -   5        X ��Name$X btnCleanPage��5�     $��0,0,5,0q�5�     
���  ��
���  ��$��Limpiar solicitud��5�     ��5�     �� *CleanFormCommand+{�5�     �� *EnableAddedItems+�� 5�     -   5        $X btnSelectArticles��5�     $��0,0,5,0q�5�     ���#00BCD4���#00BCD4$ ��Seleccionar Artículos(F3)��5�     ��5�     �� *ShowModalArticlesCommand+5�     �� 5�     -   5        $X btnSave��5�     $��0,0,5,0q�5�     ���#FF9800���#FF9800$��Guardar Borrador��5�     ��5�     �� *!ValidateOpenConfirmationCommand+{�5�     �� *EnableSavedAndSendOrder+�� 5�     -   5        $X btnSend��5�     $��0,0,5,0q�5�     ���#4ACF50���#4ACF50$��Generar Documento��5�     ��5�     �� *#!ValidateErasedConfirmationCommand+{�5      �� *EnableSavedAndSendOrder+5     5     5     � 5       IconCard#��[ 6   S 5
       5     $T 20Q�5     Y   RenderingBias$Y Quality=�5     $W 1Q�5     Z   Color$Z 	#FFECECEC��5     .+�5     ��   
BorderCard#��[ 6     5     $��30��5     $��30��5     $��5q�5     $��10q�5     $��Center=�5     $��Center=�5     
�������$
 PlaylistAddCheck=�5     5     � 5       	 Title#��[ 6   .+�5"     ��   ContentTitle#��[ 6   .+�5#     ��   	TextTitle#��[ 6    ��6C   �� *OrderType.OrderTypeName+$% Solicitud de Pedido - Tipo: {0}��5$     5&     5(     5*     5,     