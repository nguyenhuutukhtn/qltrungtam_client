   M S B A M L   `   `   `  ����U  QMaterialDesignThemes.Wpf, Version=1.5.0.523, Culture=neutral, PublicKeyToken=nulleHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf  5   	    EnglishCenterApp'   !EnglishCenterApp.View.LoginWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   XwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf     5   	     � Title$  LoginWindow��5   	   $	��300��6   $	��500��6*    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ /Resources/ic_apple.png��5	   	   .��5
      � ��5   
   �� 5       �� ImageSource$ /Resources/bigben.jpg��6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      .+�5   
   �� $��0��6   $��0��6!   
�������$��10q�6D   $��16(�6P   $
��Bold"�6^   ĐĂNG NHẬP6{   � 5   
   $��0��6   $��1��6   $	��Top=�6,   $��Right=�6D   $��	0 -1 -1 0q�6`   $��25��6s   $��25��6~   .+�5      �� $��0 -3 1 3q�6    � ToolTip$ Đóng��6(   $��0q�67   $	��❌��6L   
���������5      �� 5      	 �� 
TargetType"	 ��6   .�5      �� 
 �� Property
 � �� �� Value
 ���� 67   �� 5       
 � �� 5!      �� 5"   "    �� 
TargetType" ��62   .R�5#   &   �� #��z��6-   ._�5$   *   �� $��Center=�6;   $��Center=�6X   5%   '   5&   #   5(       �� Triggers 5)      P� 5*       P� Property �@J�IsMouseOver P� Value . . �5+   "   �� 
 � ��
 �  ��6?   5,      5.      50      51      �� 53   
   $��1��6   $��0��6   $��Right=�6-   $��10q�6I   $��30��6U   $��30��6`   $��/Resources/user.png��6l   �� 54   
   $��2��6   $��0��6   $��Right=�6-   $��10q�6I   $��30��6U   $��30��6`   $��/Resources/locked.png��6l   �� 56   
   -   5        $��
tbUsername��56   q   $��1��6   $��1��6   $��Center=�6/   $	��250��6J   $
��Left=�6V   
����������	#89FFFFFF.   (MaterialDesignThemes.Wpf.TextFieldAssist   Hint$ Tên đăng nhập��6�   $��14(�6�   6�   G� 57   
   -   5        $��tbPass��57   u   $��2��6   $��1��6#   $��Center=�63   $	��250��6N   $
��Left=�6Z   
����������	#89FFFFFF$ Mật khẩu��6�   $��14(�6�   6�   �� 59   
   -   5        $��loginButton��59   _   $��3��6   $��0��6   $��2��6.   $��Center=�6B   
�������.��6�   Đăng nhập6�   5<      5=      