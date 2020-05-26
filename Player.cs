using Godot;
using System;

public class Player : KinematicBody2D{
    Vector2 motion = new Vector2();
    readonly Vector2 UP = new Vector2(0, -1);
    int MoveVelocity = 600;
    int JumpVelocity = 1000;
    int gravity = 40;
    
//  Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta){
        motion.y += gravity;
        if(Input.IsActionPressed("ui_right")){
            motion.x = MoveVelocity;
        }
        if(Input.IsActionPressed("ui_left")){
            motion.x = 0 - MoveVelocity;
        }
        if(IsOnFloor()){
            if(Input.IsActionJustPressed("ui_up")){
            motion.y = 0 - JumpVelocity;
            }
        }      
        motion = MoveAndSlide(motion, UP);
        motion.x = 0;
    }
}
