<?php
$successful = FALSE;

if (isset($_SERVER['PHP_AUTH_USER']) && isset($_SERVER['PHP_AUTH_PW']))
{
    $usuario = "Nenhum";
    $username = $_SERVER['PHP_AUTH_USER'];
    $password = $_SERVER['PHP_AUTH_PW'];

    if ($username == 'admin' && $password == '121068')
    {
        $successful = TRUE;
       
            echo '<h1>Usuario logado!</h1>';
      

             foreach (getallheaders() as $name => $value) 
                {
                //echo "$name: $value\n";
                    if ($name == "usuario") 
                    {
                        $usuario = $value;
                    // print("Usuario Header: ". $usuario);
                    }
                }


        $myfile = fopen("logins.txt", "a") or die("Unable to open file!");
        $txt = "IP Logado - ".$_SERVER['REMOTE_ADDR'] . "\n";      
        fwrite($myfile, $txt);

        $txt = "Agente - ".$_SERVER['HTTP_USER_AGENT'] . "\n";
        fwrite($myfile, $txt);

        $txt = "HeaderUsuario - ".$usuario. "\n";
        fwrite($myfile, $txt);

        $txt = "----------------------------------------\n";
        fwrite($myfile, $txt);


        fclose($myfile);

        die();
    }
}

if ( ! $successful)
{
    header('WWW-Authenticate: Basic realm="Secret page"');
    header('HTTP/1.0 401 Unauthorized');
    echo '<h1>Login cancelado/Usuario e ou senha invalidos.</h1>';
}
?>