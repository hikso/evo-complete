   M S B A M L   `   `   `  ����A  =EVO_PV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EVO_PV.ViewsEVO_PV.Views  5      3clr-namespace:EVO_PV.UtilitiesEVO_PV.Utilities  5      (    "EVO_PV.Views.UCArticleSelectedInfo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:EVO_PV.Views     5      1local1clr-namespace:EVO_PV.Utilities     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $��	-25,5,0,0q�5	      $��Stretch=�5
      $��Stretch=�5      
�������
���   �$��1q�5        � 	Resources  5       �� MergedDictionaries �� Source*   $EVO_PV.Utilities.VisibilityConverter   VisibilityConverter  VisibilityConverterBool'   !EVO_PV.Utilities.DecimalConverter  decimalConverter�� 5   
    5      �� 5      $< 6/EVO_PV;Component/Resources/Dictionaries/DictTags.xaml?�6%   �� 5      $2 ,/EVO_PV;Component/Resources/Style/style.xaml?�6%   %W   &	        &	      &	 &       5      6)   �� 5      6+     5      6&   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5       $	��150 �6   �� 5!      �� 5"      $	��130 �6   �� 5#      $	��130 �6   �� 5$      $	��130 �6   �� 5%      $	��130 �6   �� 5&      $	��130 �6    � RowDefinitions 5(   
   �� 5)      $��40 �6   �� 5*      $��40 �6   �� 5+      .+�5-   
   �� $��0��5.      $��0��5/      $��8��50      $��	10,-5,0,0q�51      $
��Left=�52      $+��%Está pesando el siguiente artículo:��53        
LabelStyle#��[ 54      �� 56   
   $��1��57      $��0��58      $��8��59      $��
30,-10,0,0q�5:      $
��Left=�5;      $��12(�5<        TextHeaderView#��[ 5=      $��Código Artículo��5>      �� 5@   
   $��2��5A      $��0��5B      $��
35,-30,0,0q�5C      $
��Left=�5D      ��5E      �� *ArticleSelected.ArticleCode+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5G   
   $��1��5H      $��1��5I      $��8��5J      $��
30,-10,0,0q�5K      $
��Left=�5L      $��12(�5M      #��[ 5N      $��Nombre��5O      �� 5Q   
   $��2��5R      $��1��5S      $��
35,-30,0,0q�5T      $
��Left=�5U      ��5V      �� *ArticleSelected.ArticleName+$ TwoWay=�$ PropertyChanged=��� 5X   
   $��1��5Y      $��2��5Z      $��8��5[      $��
30,-10,0,0q�5\      $
��Left=�5]      $��12(�5^      #��[ 5_      $��Estado��5`      �� 5b   
   $��2��5c      $��2��5d      $��
35,-30,0,0q�5e      $
��Left=�5f      ��5g      �� *ArticleSelected.State+$ TwoWay=�$ PropertyChanged=��� 5i   
   $��1��5j      $��3��5k      $��8��5l      $��
30,-10,0,0q�5m      $
��Left=�5n      $��12(�5o      #��[ 5p      $��Cantidad Solicitada��5q      �� 5s   
   $��2��5t      $��3��5u      $��
35,-30,0,0q�5v      $��Right=�5w      ��5x      `� 5y       �� StringFormat$ 	 {0} {1} ��6   .1�5z      ��  �� 	Converter# [ 6   	 �� Path$'	 !ArticleSelected.QuantityRequested�6L   �� 5{      $!	 ArticleSelected.MeasureUnit�6   5|      5~      �� 5�   
   $��1��5�      $��4��5�      $��8��5�      $��
30,-10,0,0q�5�      $
��Left=�5�      $��12(�5�      #��[ 5�      $��Cantidad Aprobada��5�      $
��Wrap=�5�      �� 5�   
   $��2��5�      $��4��5�      $��
35,-30,0,0q�5�      $��Right=�5�      ��5�      `� 5�      $ 	 {0} {1} ��6   .1�5�      �� # [ 6   $%	 ArticleSelected.QuantityAprobed�6L   �� 5�      $!	 ArticleSelected.MeasureUnit�6   5�      5�      �� 5�   
   $��1��5�      $��5��5�      $��8��5�      $��
30,-10,0,0q�5�      $
��Left=�5�      $��12(�5�      #��[ 5�      $��Cantidad Enviada��5�      $
��Wrap=�5�      �� 5�   
   $��2��5�      $��5��5�      $��
35,-30,0,0q�5�      $��Right=�5�      ��5�      `� 5�      $ 	 {0} {1} ��6   .1�5�      �� # [ 6   $$	 ArticleSelected.QuantitySended�6L   �� 5�      $!	 ArticleSelected.MeasureUnit�6   5�      5�      �� 5�   
   $��1��5�      $��6��5�      $��8��5�      $��
30,-10,0,0q�5�      $
��Left=�5�      $��12(�5�      #��[ 5�      $��Cantidad Recibida��5�      $
��Wrap=�5�      �� 5�   
   $��2��5�      $��6��5�      $��
35,-30,0,0q�5�      $��Right=�5�      ��5�      `� 5�      $  {0} {1}��6   .1�5�      �� # [ 6   $%	 ArticleSelected.QuantityReceive�6L   �� 5�      $!	 ArticleSelected.MeasureUnit�6   5�      5�      5�      5�      