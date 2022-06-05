
<?php
$hidden = $_POST['hidden'];
$form_a_z = $_POST['form_a_z'];
$form_ab_zb = $_POST['form_ab_zb'];
$form_zerro_one = $_POST['form_zerro_one'];
$form_amount_symbols_pass = $_POST['form_amount_symbols_pass'];
$form_amount_pass = $_POST['form_amount_pass'];
$form_spec = $_POST['form_spec'];
$form_rus_min = $_POST['form_rus_min'];
$form_rus_max = $_POST['form_rus_max'];

//делаем ограничение
if($form_amount_symbols_pass > "64") $form_amount_symbols_pass = "64";
if($form_amount_pass > "128") $form_amount_pass = "128";

//если форма отправлялась - генерируем пароли
if($hidden != ""){
	if ($form_amount_symbols_pass > 4) {
print('<div style="width:600px; padding:10px;"><font style="text-indent:7px; text-decoration:none; font-size:15px; font-weight:bold; color:#0094db;">Результат<br><br></font>');
//выбраны ли символы для генерации
if($form_a_z == 'y' || $form_ab_zb == 'y' || $form_zerro_one == 'y'){
if($form_a_z == 'y') $az = range("a","z");
else $az = array();
if($form_ab_zb == 'y') $az_big = range("A","Z");
else $az_big = array();
if($form_zerro_one == 'y') $zerro_one = range(0,9);
else $zerro_one = array();
if($form_spec == 'y') $special = range("!","+");
else $special = array();
if($form_rus_min == 'y'){ 
	foreach (range(chr(0xE0), chr(0xFF)) as $b)
    $rusmin[] = iconv('CP1251', 'UTF-8', $b);
}else{ $rusmin = array();}
if($form_rus_max == 'y'){
	foreach (range(chr(0xC0), chr(0xDF)) as $b)
    $rusmax[] = iconv('CP1251', 'UTF-8', $b);
}else{ $rusmax = array();}
//массив нужных символов
$need_symbols = array_merge($az,$az_big,$zerro_one,$special,$rusmin,$rusmax);
$count_symbols = count($need_symbols);

//цыкл для создания паролей
for($i = '0'; $i < $form_amount_pass; $i++){
//вложенный цыкл для генерирования пароля
for($a = '0'; $a < $form_amount_symbols_pass; $a++){
$max_gen = $count_symbols - 1;
$gen_sym = mt_rand(0, $max_gen);
$symbol = $need_symbols[$gen_sym];
$password = "$password$symbol";
}
print("$password<br>");
unset($password);
}
}
else print('Не выбраны символы для генерации');
print('</div>');
} else {
echo "Нельзя меньше 4 символов!";
}
}


//выводим форму
print("
<table>
<form name=\"forma\" action=\"index.php\" method=\"post\">
<input type=\"hidden\" name=\"hidden\" value=\"y\" />

<tr><td>Использовать символы a-z - </td><td valign=\"bottom\"><input type=\"checkbox\" name=\"form_a_z\" value=\"y\" checked/></td></tr>
<tr><td>Использовать символы A-Z - </td><td valign=\"bottom\"><input type=\"checkbox\" name=\"form_ab_zb\" value=\"y\" checked/></td></tr>

<tr><td>Использовать символы а-я - </td><td valign=\"bottom\"><input type=\"checkbox\" name=\"form_rus_min\" value=\"y\" checked/></td></tr>
<tr><td>Использовать символы А-Я - </td><td valign=\"bottom\"><input type=\"checkbox\" name=\"form_rus_max\" value=\"y\" checked/></td></tr>

<tr><td>Использовать символы 0-9 - </td><td valign=\"bottom\"><input type=\"checkbox\" name=\"form_zerro_one\" value=\"y\" checked/></td></tr>
<tr><td>Использовать символы спец - </td><td valign=\"bottom\"><input type=\"checkbox\" name=\"form_spec\" value=\"y\" checked/></td></tr>
<br>
<tr><td>Количество символов в паролях (до 64) - </td><td valign=\"bottom\"><input type=\"text\" style=\"width:30px;\" name=\"form_amount_symbols_pass\" size=\"5\" maxlenght=\"5\" value=\"16\"/></td></tr>
<tr><td>Количество паролей (до 128) - </td><td valign=\"bottom\"><input type=\"text\" style=\"width:30px;\" name=\"form_amount_pass\" size=\"5\" maxlenght=\"5\" value=\"1\"/></td></tr>

<tr><td><br><br><input type=\"submit\" value=\"Генерировать\" />
</form>
</table>
");
?>