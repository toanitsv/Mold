   M S B A M L   `   `   `  ����I  EMoldCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MoldCalculator.ViewsMoldCalculator.Views  5   	   )    #MoldCalculator.Views.SupplierWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MoldCalculator.Views     5   	   -   5        $��14(�5        � Title$  Mold - Supllier��5   	   $	��450��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�6Q   .��5	      � $��5q�6    � ColumnDefinitions 5
   
   �� 5      �� 5      $��* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     5      �� 5      $
��Auto �6#   �� 5      .+�5      �� $��SupplierID: ��6   $��Center=�6,   �� 5      $��Supplier Name: ��6   $��Center=�6/   $��1��6J   �� 5      $��Description: ��6   $��Bottom=�6-   $��2��6H   �� 5      -   5         ��Name$ txtSupplierID��5      $��1��6-   {�.  $��Center=�6�   ��6O   ��  �� ElementName$ btnSave�� �� Path$ ActualHeight�6�   �� 5      -   5        $ txtSupplierName��5      $��1��6/   $��1��6?   $��0,5,0,5q�6L   $��Center=�6�   ��6]   �� $ btnSave��$ ActualHeight�6�   �� 5      -   5        $ txtDescription��5      $��1��6.   $��2��6?   $��Italic$�6L   $	��100��6_    �� TextWrapping$
 Wrap=�6o   �� 5!      -   5         ��Name$ btnSave��5!      $��1��6&   $��3��66   $��0,5,0,0q�6C   $	��100��6T   $��Right=�6`   $
��Save��6|   6�   5#      � 5$   
   $��1��6   $��5,0,0,0q�6   .+�5%      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 
dgSupplier��5%      
   AutoGenerateColumns
 .     CanUserAddRows .     CanUserResizeRows .     CanUserDeleteRows .    AlternatingRowBackground
 ����� �� AlternationCount$ 2��5'   8      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 ����� � ContextMenu 5*      �� 5+      .@�5,      m� -   5         m�Name$ miRemove��5,   #   $��Remove��65   6E   5-         Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *
SupplierID+  51      $ SupplierName��6)      
Foreground
 ��  � .  6c   �� *SupplierName+  52      $ Description��6)    .    	FontStyle$ Italic$�6p    6P   �� *Description+6p     53      $ Revise Time��6)    .  6P   �� *ModifiedTime+ �� StringFormat$ 
MM/dd/yyyy��55      56      57      58      