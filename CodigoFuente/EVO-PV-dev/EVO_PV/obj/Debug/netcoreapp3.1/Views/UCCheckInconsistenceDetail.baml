   M S B A M L   `   `   `  ����
  EVO_PV-    'EVO_PV.Views.UCCheckInconsistenceDetail   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          >�Name$  UserControl��5
      $
|�True��5	       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $2 ,/EVO_PV;Component/Resources/Style/style.xaml?�6%   %    5      .��5      � ���#eee � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��70 �6   6*   �� 5      6   .+�5   
   �� -   5         ��Name$ 
NewRequest��5      $��0��6    "  MaterialDesignRaisedDarkButton#��[  62   $	��150��6k   $��0q�6w   $��0 0 40 0q�6�   ���#00BCD4���#00BCD4$	��Top=�5    @   $��Right=�6X   ��5!      ��  �� Path$ CmdBack�.��5"      � $	��150��6   $��Center=�6   .+�5#      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ChevronLeft=�6*   ���#FFFFFF$��10 2 0 0q�6R   �� 5$      $��Center=�6   $��REGRESAR��69   5%      5&      � 5(   
   $��1��6   .+�5*      #  MaterialDesignThemes.Wpf.Card  $��
30 0 30 10q�6"   .��5,      �   ContentCard#��[ 6   $	��Top=�6<    5.      �� 5/      $��* �6+    52      �� 53      6+   �� 54      6+   �� 55      6+   .+�58      �� $��0��6!   $��80��6.   .+�5:      � $��	0 10 0 20q�6    5<      �� 5=   "   $��1* �63   �� 5>   "   $��1* �63   �� 5?   "   $��1* �63    5B      �� 5C   "   62   �� 5D   "   62   �� 5E   "   62   .+�5H      �� $��0��6)   $��0��69     
HeaderView#��[ 6F   .+�5I   "   �� $��Punto de Venta: ��6,     TextHeaderView#��[ 6D   �� 5J   "   ��6,   �� *Inconsistence.SalePoint+5K      �� 5L      $��1��6)   $��0��69   #��[ 6F   .+�5M   "   �� $��Fecha: ��6,   #��[ 6;   �� 5N   "   ��6,   �� *Inconsistence.EvidenceDate+5O      �� 5P      $��2��6)   $��0��69   #��[ 6F   .+�5Q   "   �� $��Correo Origen: ��6,   #��[ 6C   �� 5R   "   ��6,   �� *Inconsistence.EmailFrom+5S      �� 5U      $��0��6)   $��1��69   #��[ 6F   .+�5V   "   �� $��Número Pedido: ��6,   #��[ 6C   �� 5W   "   ��6,   �� *Inconsistence.RequestNumber+5X      �� 5Y      $��1��6)   $��1��69   #��[ 6F   5[      �� 5\      $��2��6)   $��1��69   #��[ 6F   5^      �� 5`      $��0��6)   $��2��69   #��[ 6F   .+�5a   "   �� $��	Entrega: ��6,   #��[ 6=   �� 5b   "   ��6,   �� *DeliveryNumber+5c      �� 5d      $��1��6)   $��2��69   #��[ 6F   .+�5e   "   �� $��	Usuario: ��6,   #��[ 6=   �� 5f   "   ��6,   �� *Inconsistence.User+5g      �� 5h      $��2��6)   $��2��69   #��[ 6F   .+�5i   "   �� $��Correo Destino: ��6,   #��[ 6D   �� 5j   "   ��6,   �� *Inconsistence.EmailTo+5k      5m      5o      �� 5q      $��1��6!   $��1��6.   .+�5s      &   System.Windows.Controls.DataGrid  	   SelectionUnit$	 FullRow=�6#   $
��Auto��5t   %   
   HeadersVisibility$
 Column=�5u   %      AutoGenerateColumns$ False��5w   %      CanUserAddRows$ False��5x   %      CanUserDeleteRows$ False��5y   %      CanUserResizeColumns$
 True��5z   %      CanUserReorderColumns$ False��5{   %      SelectionMode$ Single=�5|   %   ��5v   %   �� * Inconsistence.DocumentArticles+   Columns 5~      0  *System.Windows.Controls.DataGridTextColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo Articulo��65      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6s      
IsReadOnly$
 True��6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� $ ArticleCode�6     5�   "   $ Nombre��65   $	 400 6j   $
 True��6v    6E   �� $ ArticleName�6v     5�   "   $ Inconsistencias��65   $	 300 6p   $
 True��6|    6N   �� $ Document�6|   5�      5�      �� 5�      $��2��6!   .+�5�      �  5�      �� 5�   "   $��1* �63   �� 5�   "   $��1* �63    5�      �� 5�   "   $��70 �60   6>   �� 5�   "   62   .+�5�      �� $��0��6)   $��0��66   #��[ 6F   .+�5�   "   �� #��[ 6,   Observaciones6c   5�      �� 5�      $��0��6)   $��1��66   #��[ 6F   .+�5�   "   �� #��[ 6,   
Documentos6`   5�      �� 5�      $��1��6)   $��0��66   .+�5�   "   �� .+�5�   &   �� $	��500��6.    �� 
IsReadOnly$
 True��5�   )   $��	30 5 30 5q�5�   )   $��1 1 1 1q�5�   )   ���#eee �� TextWrapping$
 Wrap=�5�   )    �� AcceptsReturn$
 True��5�   )   " �� VerticalScrollBarVisibility$ Visible=�5�   )   ��5�   )   �� *Inconsistence.Description+5�   #   5�      �� 5�      $��1��6)   $��1��66   .+�5�   "     $	 FullRow=�6+   $	��300��5�   %   $

 None=�5�   %   $ False��5�   %   $ False��5�   %   $ False��5�   %   $
 True��5�   %   $ False��5�   %   $ Single=�5�   %   ��5�   %   �� *Inconsistence.Files+ �� SelectedItem 5�   %   �� *FileSelected+ 5�   &     5�   *   $	 200 6_   $
 True��6k    6=   �� $ FileName�6k   4  .System.Windows.Controls.DataGridTemplateColumn  5�   *   $	 100 6A      CellTemplate 5�   .   �� 5�   2   .R�5�   6   ��  �� Orientation$ 
Horizontal=�6A   .+�5�   :   �� ���#00BCD4���#00BCD4$��0 0 5 0q�5�   =   ��5�   =   �� $ DataContext.CmdViewFile� �� RelativeSource �� *FindAncestor+ �� AncestorType"  .��5�   >     $	 Eye=�6V   $��Center=�6a   ���#FFFFFF6~   5�   ;   5�   7   5�   3   5�   +   5�   #   5�      5�      5�      5�      5�      � 5�        IconCard#��[ 6    J� Effect 5�      3	  -System.Windows.Media.Effects.DropShadowEffect	  5�        	  
BlurRadius$  20Q�6'   ! 	  Color$! 	#FFECECEC��67   " 	  RenderingBias$" Quality=�6I   # 	  ShadowDepth$# 1Q�6a   .+�5�      ��   
BorderCard#��[ 6     5�      $ PlaylistAddCheck=�6*   $��Center=�6B   $��Center=�6_   $��5q�6z   
�������$��30��6�   $��30��6�   $��10q�6�   5�      � 5�       	 Title#��[ 6   .+�5�      ��   ContentTitle#��[ 6   .+�5�      �� $"��VER DETALLE INCONSISTENCIAS ��6      	TextTitle#��[ 6D   5�      5�      5�      )
  #MaterialDesignThemes.Wpf.DialogHost
  5�   
   $��1��6$   $
��auto��6O   $
��auto��6\   $��Center=�6j   $��Center=�6�   $ 
  IsOpen$ 61   �� *
DialogOpen+% 
  DialogContent% 5�      �� 5�      $��15q�6   .+�5�      �� -   5        $��
imgDynamic��5�      ��6.   �� *	ImgSource+�� 5�      $��10q�6   $��Cerrar��6L   ��6)   �� *CmdCloseDialog+6L   5�      5      5     5     