   M S B A M L   `   `   `  ����D  @TelegaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TelegaWPF	TelegaWPF  5   	       TelegaWPF.AdminWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TelegaWPF     5   	   -   5          � Title$  AdminWindow��5	   	   $	��450��6   $	��800��6*   ���	#FF6D3859.��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��280 �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ ShowLogs��5      
����������	#FF681C4C$��Mistral)�6M   $��18(�6b   $��0��5      $��1��6   $��3��6*    "  MaterialDesignFlatDarkBgButton#��[  5       � ToolTip$" MaterialDesignFlatDarkButton��5      $,��&Посмотреть логи чата��5      ��6,   Z� 6C   �� 5   
   -   5         ��Name$ 
MessageLbx��5      $��1��6&   $��1��63   $��3��6C   
�������$��Mistral)�6j   $��16(�6   �� 5   
   -   5        $
 Send��5      
����������	#FF681C4C$��Mistral)�6I   $��18(�6^   $��Bottom=�5      $��2��5      $��3��6   #��[  5      $" MaterialDesignFlatDarkButton��5       $��45��5!      $��Отправить��5"      ��6!   Z� 68   �� 5#   
   -   5         ��Name$
 Name��5#      $��Mistral)�6    $��18(�65   
�������$��5q�6V   $��2��5$      $��2��6    �� AcceptsReturn$
 True��5%       �� TextWrapping$
 Wrap=�5&      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Сообщение��5'      
 �� 
CaretBrush
 68   Z�  �� SelectionBrush 6N   Z� �� 5(   
   -   5        $
 Exit��5(      
����������	#FF681C4C$��Mistral)�6I   $��18(�6^   $��Bottom=�5)      $��2��5*      $��1��6   #��[  5+      $" MaterialDesignFlatDarkButton��5,      $��45��5-      $��
Выйти��5.      ��6   Z� 64   �� 5/   
   $��Mistral)�6   $��18(�6)   $��0��50      $��0��6   $��Center=�51      $��Center=�6*   $��Пользователи:��52      
�������6"   �� 53   
   -   5        $ UsersLbx��53      $��1��6$   $��0��61   $��2��6A   $��Mistral)�6R   $��16(�6g   ���	#DDFFFFFF6u    � 54   
   -   5          �Name$ Frame��54      $��3��6     � NavigationUIVisibility$ Hidden=�60   55      56      