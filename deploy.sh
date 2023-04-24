eval `ssh-agent -s`
ssh-add ~/.ssh/id_rsa

echo 'updating project...'

cd /home/mykola/dotNetProjects

ssh -F ~/.ssh/config vm rm -rf /home/mykola/dotnetProjects/labrob1/*
scp -F ~/.ssh/config -r labrob1/* vm:/home/mykola/dotnetProjects/labrob1/

ssh-agent -k

