   M S B A M L   `   `   `  ����I  EMoldCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MoldCalculator.ViewsMoldCalculator.Views  5   	   &     MoldCalculator.Views.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MoldCalculator.Views     5   	   -   5        $��14(�5        � 
ResizeMode$  NoResize=�6(    � Title$ LoginWindow��5   	   $	��250��6   $	��300��6*    � WindowStartupLocation$ CenterScreen=�66    � WindowStyle$
 None=�6[    � 	Resources 5
         LinearBackground �� 
StartPoint �� EndPoint � Offset � Color  LinearHearder  LinearButtonLogin��%�  &	        &	 �     &	 ;    �� 5   
   $	 0,1&�67   $	 1,0&�6H   ��5      � $
 -0.5Q�6   $
 Gray��6-   � 5      $ 1Q�6   $ Transparent��6*   5      �� 5   
   $	 0,1&�64   $	 1,0&�6E   ��5      � $
 -0.5Q�6   $ DeepSkyBlue��6-   � 5      $	 1.5Q�6   $ Transparent��6,   5      �� 5   
   $	 0,1&�68   $	 1,0&�6I   ��5      � $ 1Q�6   $ DeepSkyBlue��6*   � 5      $
 -0.4Q�6   $ Transparent��6-   5      5      .��5      �� 
�������$��1,1,1,1q�6$   ._�5   
   � 	 � RowDefinitions	 5       �� 5!      $
��auto �6    �� 5"      .+�5$      � -   5        
 �Name$
 
gridHeader��5$      $��30��6'   #��[ 63    � ColumnDefinitions 5%      �� 5&      �� 5'      $
��auto �6'   �� 5(      $
��auto �6'   .+�5*      �� $��Login Mold Calculator��6   $��Center=�69   $��Center=�6V   $��30,0,0,0q�6q   �� 5+      -   5         ��Name$ btnMinimize��5+      $��1��6H   ��5,      �� 5-       �� 
TargetType" ��6*   .R�5.      �� $��_��6(   $��Center=�61   $��25��6N    �� Padding$ 8,0,5,5q�6Y   �� 5/      50      51      ��53      �� 54       �� 
TargetType" ��6    .�55      ��  �� Property � �� �� Value
 ��  �6;    �� Triggers 56      P� 57   "    P� Property �@J�IsMouseOver P� Value . . �58   &   ��  � ��
 ��  �6C   �� 59   &    � ��$
 Bold"�6C   5:   #   5<      5>      �� 5?      -   5        $ btnClose��5?   )   $��2��6   ��5@      �� 5A      " ��6*   .R�5B      �� $��X��6(   $��Center=�61   $��Center=�6L   $��25��6i   $ 8,5,5,5q�6t   �� 5C      5D      5E      ��5G      �� 5H      " ��6    .�5I      ��  � ��
 ��  �6;    5J      P� 5K   "    �@J�IsMouseOver . . �5L   &   ��  � ��
 �  ��6C   �� 5M   &    � ��$
 Bold"�6C   5N   #   5P      5R      5S      � 5T      $��1��6   #��[  6    .+�5U      �� $��
User Name:��6   $��40,30,180,140q�6.   $��Center=�6E   �� 5V      -   5         ��Name$ txtUserName��5V      $��130,40,40,150q�6/   $��Consolas)�6F   $��Center=�6\   �� 5X      $��	Password:��6   $��40,90,180,100q�6-   $��Center=�6D   G� 5Y      -   5         G�Name$ txtPassword��5Y      $��130,90,40,100q�63   $��Center=�6J   �� 5[      -   5        $ btnLogin��5[      $��Login��6+   $��28��6;   $��40,150,40,40q�6G   #��[ 6]    �� 	IsDefault . 6�   5\      5]      5^      5_      