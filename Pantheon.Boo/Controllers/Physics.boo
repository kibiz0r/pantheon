namespace Pantheon

controller Physics:
    message Update(elapsed as single):
        pass

    message Collision(actor1 as Actor, actor2 as Actor):
        pass