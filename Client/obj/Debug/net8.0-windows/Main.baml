   M S B A M L   `   `   `  ����C  ?Chatting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ChattingChatting  5          Chatting.Main   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Chatting     5        N� Title$
  Main��5	      .��5      � 
�������.+�5   
   �� $
��Left=�6   $��	30,30,0,0q�6/   $
��Wrap=�6B   $��접속중인 유저��5      $	��Top=�6#   $��20(�6;   $
��Bold"�6I   �� 5   
   -   5         ��Name$ btn_chat_room_list��5      $	��145��6-   $��대화방 목록��6:   $
��Left=�6K   $��
70,125,0,0q�6f   $	��Top=�6z   $��18(�6�   6�   �� 5   
   -   5        $ btn_create_chat_room��5      $��대화방 생성��60   $��
0,125,70,0q�6A   $	��Top=�6U   $��18(�6m   $��Right=�6{   $	��145��6�   6�   �� 5   
   -   5         ��Name$ LV_user_list��5      $��	0,180,0,0q�6)   $	��Top=�6=   $��Center=�6U   $	��370��6r   $	��340��6~   ��5      �� 5      .R�5      �� $��10q�6!    �� Orientation$ 
Horizontal=�6-   .+�5      ��  ��Name$ Tblock_userId��6<   $��16(�6S   ��6$   �� *UserId+6S   �� 5       ��Name$ ChkBox_invitaition��6U    d� 	IsChecked 6#   ��  �� Path$ 	IsChecked� �� Mode$ TwoWay=�6U   5      5      5      �� 5   
   -   5        $ Tblock_userId��5      $
��Left=�6+   $��
280,35,0,0q�6F   $
��Wrap=�6Z   $��	TextBlock��6n   $	��Top=�6   $	��160��6�   $��16(�6�   5      5      