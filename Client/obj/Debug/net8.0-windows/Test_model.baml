   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5          Client.Test_model   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Client     5        N� Title$  
Test_model��5	      .��5      � 
�������.+�5   
   �� $
��Left=�6   $��	30,30,0,0q�6/   $��NoWrap=�6B   $	��Top=�5      $��20(�6%   $
��Bold"�63   $��모델 테스트��6E   � 5   
   $��0,100,0,100q�6   $��Center=�6$   $	��380��6A   
������� � ColumnDefinitions 5      �� 5      $	��130 �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��* �6    �� 5      $��50 �6    �� 5      $��50 �6    .+�5      �� -   5         ��Name$ btn_sel_image��5      $��이미지 선택��6,   $��20,0,0,0q�6=   $��16(�6O   $��Center=�6]   $
��Left=�6x   $��30��6�   $	��100��6�   6�   �� 5      -   5         ��Name$ TBlock_imageUri��5      $	��210��61   $��24��6=   $��Center=�6I   $��1��6f   $��NoWrap=�6v   $��Center=�6�   
�������6�   �� 5      $��3��6   $��16(�6%   $
��Left=�63   $��20,0,0,0q�6N   $
��Wrap=�6`   $��[결과]��6t   $��Center=�6�   �� 5      -   5        $ TBlock_result��5      $��1��6/   $��3��6?   $��16(�6L   $��Center=�6Z   $
��Wrap=�6w   $��Center=�6�   $	��210��6�   
���������6�   �� *Result+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5        $ btn_test��5      $��1��6'   $��2��67   $��	테스트��6D   $��0,0,20,0q�6R   $��16(�6d   $��Center=�6r   $��Right=�6�   $��30��6�   $	��100��6�   6�   �� 5      -   5         ��Name$ img_testImg��5      $
��Left=�6*   $��	20,20,0,0q�6E   $��1��6X   $	��340��6e   $��2��6q   $	��210��6�   $	��Top=�6�   5!      �� 5"   
   -   5        $ TBlock_modelId��5"      $��Right=�6,   $��	0,31,35,0q�6H   $
��Wrap=�6[   $	��Top=�5#      $��18(�6%   $��	모델명��64   $	��200��6?    �� TextAlignment$ Right=�6K   5%      5&      