   M S B A M L   `   `   `  ����I  EMoldCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MoldCalculator.ViewsMoldCalculator.Views  5   	   &     MoldCalculator.Views.OrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MoldCalculator.Views     5   	   -   5        $��14(�5        � Title$  Mold - Order��5   	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�67   .��5	      � $��5q�6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��Input Order Information��6   $��0,5,0,5q�64   
�������.��5      �  5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   .+�5      � $��0��6    5      �� 5      $
��auto �6(   �� 5      $
��auto �6(    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5       �� 5!      .+�5#      �� $��Order ID��6    $��0,0,5,0q�60   �� 5$      -   5         ��Name$ 
txtOrderID��5$      $��1��62   {�.  $��0,0,5,0q�6Q   $��Center=�6b   �� 5&      $��Outsole Code��6    $��1��64   $��5,0,5,0q�6D   �� 5'      -   5        $ txtOutsoleCode��5'      $��1��66   $��1��6F   $��5,0,5,0q�6S   $��Center=�6d   �� 5)      $��Article��6    $��2��6/   $��5,0,5,0q�6?   �� 5*      -   5        $ 
txtArticle��5*      $��2��62   $��1��6B   $��5,0,5,0q�6O   $��Center=�6`   �� 5,      $��Quantity (Pairs)��6    $��3��68   $��5,0,5,0q�6H   �� 5-      -   5        $ txtQuantity��5-      $��3��63   $��1��6C   $��5,0,5,0q�6P   $��Center=�6a   �� 5/      $	��CSD��6    $��4��6+   $��5,0,0,0q�6;   (  "System.Windows.Controls.DatePicker  50      -   5          Name$ dpCSD��50   !   $��4��60      SelectedDate$ 
04/14/1996X�6@   $��1��6Z   $��5,0,0,0q�6g   $��Center=�6x   51      �� 52      $��	Shoe Name��6   $��1��6-   $��0,5,5,0q�6:   � 53      $��2��6    54      �� 55      $
��auto �6+   �� 56      $
��auto �6+   .+�58      �� -   5        $ txtShoeName��58      $��Center=�63   $��0,0,5,0q�6V   ��6g   ��  �� ElementName$ 
txtOrderID�� �� Path$ ActualWidth���6�   �� $ 
txtOrderID��$ ActualHeight��� 59      -   5        	 ��Name$	 chkIsEnable��59      $��1��64   $��IsEnable��6D   $��Bottom=�6W   $��5,0,5,0q�6r   
 d� 	IsChecked$

 TrueY�6�   5:      �� 5;      -	   5         ��Name$ btnSave��5;      $
��Save��6*   $��4��69   $��Right=�6F   $��5,0,0,0q�6b   ��6s   �� $ dpCSD��$ ActualWidth���6�   �� $ dpCSD��$ ActualHeight�6�   5<      5=      �� 5?   
   $��Size Run��6   $��1��6%   $��	0,10,0,10q�62   $��0,5,0,5q�6E   
�������.��5@      �  5A      �� 5B      $
��auto �6$   �� 5C      $
��auto �6$   .+�5E      �  5F      �� 5G      $
��auto �6+   �� 5H      $
��auto �6+   �� 5I      $��* �6+   .+�5K      �  5L      �� 5M      $
��auto �6,   .+�5O      �� -
   5         ��Name$ cbOutsoleCode��5O   #    �� DisplayMemberPath$ OutsoleCode��6:    �� SelectedValuePath$ OutsoleCode��6Z   6z   5P      � 5R      $��1��6    5S      �� 5T      $
��auto �6,   .+�5V      �� -   5        $ 
btnAddSize��5V   !   $��Add Size��65   $��5,0,5,0q�6H   ��5W      �� 5X   "    �� 
TargetType" ��62   .R�5Y   &   �� �� 5Z      5[   '   5\   #   ��5^      �� 5_   "    �� 
TargetType" ��6(   .�5`   &   ��  �� Property � �� �� Value
 ��  �6C    �� Triggers 5a   &   P� 5b   *    P� Property �@J�IsMouseOver P� Value . . �5c   .   ��  � ��
 �  ��6K   �� 5d   .    � ��$
 Bold"�6K   �� 5e   .    �@�Cursor$
 Hand��6G   5f   +   5h   #   5j      5k      � 5m      $��2��6   .+�5n      �� -   5         ��Name$ 
scrSizeRun��5n   '   $
��Auto=�6;   $��Hidden=�6`   .��5o      � -   5         �Name$ 	wpSizeRun��5o   (    � Orientation$ 
Horizontal=�6;   5p      5q      5r      5s      � 5t      $��1��6   $��0,2,0,0q�6$   .+�5u      �� -   5        $ btnSizeRunSave��5u      $��Save Size Run��65   $��Right=�6M   $��5,0,0,0q�6�   ��6i   �� $ btnSave��$ ActualWidth���6�   �� $ btnSave��$ ActualHeight�6�   5v      5w      5x      � 5z   
   $��2��6   $��0,10,0,0q�6   .+�5{      &   System.Windows.Controls.DataGrid  -   5          Name$ dgOrder��5{         AutoGenerateColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserDeleteRows .    AlternatingRowBackground
 ����� �� AlternationCount$ 2��5}   8       HorizontalGridLinesBrush
  �����!   VerticalGridLinesBrush
! �����" � ContextMenu" 5�      �� 5�      .@�5�      m� -   5        # m�Name$# miRemove��5�   #   $��Remove��65   6E   5�      $   Columns$ 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn%   Header$% ID��6)   &   
IsReadOnly& . 1  +System.Windows.Controls.DataGridBoundColumn'   Binding' 6G   �� *	OrderID+  5�      $% Outsole Code��6)   & . ' 6Q   �� *OutsoleCode+  5�      $% Article��6)   & . ' 6L   �� *	Article+  5�      $% 	Shoe Name��6)   & . ' 6N   �� *
ShoeName+  5�      $	% CSD��6)   & . ' 6H   �� *CSD+( �� StringFormat$( 
MM/dd/yyyy��  5�      $% Quantity��6)   & . ' 6M   �� *
Quantity+4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      )   Width5  /System.Windows.Controls.DataGridLengthConverter$
) Auto 6-   & . $% 	Is Enable��6L   ' 6`   �� *
IsEnable+  5�      $% Revise Time��6)   & . ' 6P   �� *ModifiedTime+$( 
MM/dd/yyyy��5�      5�      5�      5�      