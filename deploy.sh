eval `ssh-agent -s`
ssh-add ~/.ssh/id_rsa

echo 'updating project...'

PROJECTS_PATH="/home/mykola/dotNetProjects"

cd $PROJECTS_PATH

ssh -F ~/.ssh/config vm rm -rf $PROJECTS_PATH/labrob1/*
scp -F ~/.ssh/config -r labrob1/* vm:$PROJECTS_PATH/labrob1/

ssh-agent -k