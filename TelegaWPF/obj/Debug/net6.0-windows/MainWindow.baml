   M S B A M L   `   `   `  ����D  @TelegaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TelegaWPF	TelegaWPF  5   	       TelegaWPF.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TelegaWPF     5   	     � Title$  
MainWindow��5	   	   $	��300��6   $	��400��6)   $	��300��65   $	��400��6E   ���	#FF6D3859.��5
      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��5      $��Center=�5      $��Center=�6*   $��22(�5      $��Mistral)�6   $?��9Добро пожаловать в сетевой чат!��5      
�������64   �� 5   
   -   5         ��Name$
 Name��5      ���	#FFAF769A
�������$��1��5      $��5q�5      $��Mistral)�6   $��18(�6-   $��Center=�5       �� AcceptsReturn$
 True��5       �� TextWrapping$
 Wrap=�5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$4 .Введите имя пользователя��5       �� 
CaretBrush 6G   Z�  �� SelectionBrush 6]   Z� �� 5   
   -   5         ��Name$ Create��5      
����������	#FF681C4C$��Mistral)�6K   $��18(�6`   $��2��5      $��5q�6    "  MaterialDesignFlatDarkBgButton#��[  5       	 � ToolTip$"	 MaterialDesignFlatDarkButton��5!      $&�� Создать новый чат��5"      ��6)   Z� 6@   �� 5#   
   -   5        $ Connect��5#      
����������	#FF681C4C$��3��5$      $��5q�6   $��Mistral)�6%   $��18(�6:   #��[  5%      $"	 MaterialDesignFlatDarkButton��5&      $?��9Присоединиться к текущему чату��5'      ��66   Z� 6M   �� 5(   
   -   5        $ IP��5(      ���	#FFAF769A
�������$��4��5)      $��5q�5*      $��Mistral)�6   $��18(�6-   $��Center=�5+      $
 True��5,      $
 Wrap=�5-      $ IP адрес чата��5.      5/      50      